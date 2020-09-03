using FFTWSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace WaveletTransformCWTFT.Wavelet
{
    /// <summary>
    /// CWTFT
    /// </summary>
    public class CWTFT
    {
        /// <summary>
        /// CWTFT：基于FFT的小波变换，91*51200大概耗时4S。
        /// </summary>
        /// <param name="signal">信号源数据</param>
        /// <param name="sampleFrequency">采样频率</param>
        /// <param name="voicesperoctave">倍频程</param>
        public static CWTFTModel Execute(double[] signal, double sampleFrequency, int voicesperoctave = 12)
        {
            double s0 = 0, len = 0;
            if (voicesperoctave == 4)
            {
                s0 = 2.95480023611212 / sampleFrequency;
                len = voicesperoctave * 7.51586947392636;
            }
            else if (voicesperoctave == 24)
            {
                s0 = 2.70956077884719 / sampleFrequency;
                len = voicesperoctave * 7.50000099529183;
            }
            else 
            {
                s0 = 2.78896039134963 / sampleFrequency;
                len = voicesperoctave * 7.58333225642125;
            }

            double a0 = Math.Pow(2, 1.0 / voicesperoctave), dt = 1 / sampleFrequency;

            List<double> scales = new List<double>();//尺度
            for (double i = 0; i <= len; i++)
                scales.Add(s0 * Math.Pow(a0, i));

            int nbSamp = signal.Length;
            double meanSIG = signal.Average();
            for (int i = 0; i < nbSamp; i++)
                signal[i] -= meanSIG;

            double log2 = Math.Log(nbSamp, 2) + 0.4999;
            double np2 = 1 + (log2 > 0 ? Math.Floor(log2) : Math.Ceiling(log2));

            //wextend('1d',pad_MODE,x,2^np2-nbSamp,'r');
            int np2len = (int)Math.Pow(2, np2) - nbSamp;
            List<double> x = signal.ToList();
            for (int i = 0; i < np2len; i++)
                x.Add(0);

            int n = x.Count, nf = n / 2;//Length of data plus any extension
            double fixn = Math.Floor(n / 2.0), md = (2 * Math.PI) / (n * dt);
            // Construct wavenumber array used in transform
            List<double> omega = new List<double>() { 0 };
            for (double i = 1; i <= fixn; i++)
                omega.Add(i * md);
            int fixnm = (int)Math.Floor((n - 1) / 2.0) - 1;
            for (int i = fixnm; i >= 0; i--)
                omega.Add(-omega[i]);
            double[] f = Fft(x.ToArray(), true);

            //[psift,frequencies]  = waveft(WAV,omega,scales);
            double StpFrq = omega[1];
            int NbFrq = omega.Count, NbSc = scales.Count;
            nbSamp = nbSamp * 2;
            double SqrtNbFrq = Math.Sqrt(NbFrq);
            double cfsNORM = Math.Sqrt(StpFrq) * SqrtNbFrq;
            double mul = 0.751125544464943 * cfsNORM;
            //最终的时频结果数据
            double[][] psift = new double[NbSc][];
            //最终的频率
            double[] frequencies = new double[NbSc], temp = new double[NbFrq * 2];
              
            for (int jj = 0; jj < NbSc; jj++)
            {
                double sjj = scales[jj], ms = mul * Math.Sqrt(sjj);
                for (int i = 0; i < NbFrq; i++)
                {
                    double p = sjj * omega[i] - 6;
                    double t = ms * Math.Exp(-p * p / 2.0);
                    int idex = 2 * i, idexp = idex + 1;
                    temp[idex] = f[idex] * t;
                    temp[idexp] = f[idexp] * t;
                }
                frequencies[jj] = 0.954929658551372 / sjj;
                psift[jj] = Ifft(temp).Take(nbSamp).ToArray();
            }


            int row = psift.GetLength(0), col = psift[0].Length / 2;
            double[][] res = new double[row][];
            for (int i = 0; i < row; i++)
            {
                double[] ress = new double[col];
                for (int j = 0; j < col; j++)
                {
                    int idex = 2 * j, idexp = idex + 1;
                    double item1 = psift[i][idex], item2 = psift[i][idexp];
                    ress[j] = Math.Sqrt(item1 * item1 + item2 * item2) / 25.7565252381060;//25.7565252381060为固定参数
                }
                res[i] = ress;
            }

            return new CWTFTModel {
                result = res,
                frequencies = frequencies
            };
        }

        /// <summary>
        /// Computes the fast Fourier transform of a 1-D array of real or complex numbers.
        /// </summary>
        /// <param name="data">Input data.</param>
        /// <param name="real">Real or complex input flag.</param>
        /// <returns>Returns the FFT.</returns>
        private static double[] Fft(double[] data, bool real)
        {
            // If the input is real, make it complex
            if (real)
                data = ToComplex(data);
            // Get the length of the array
            int n = data.Length;
            /* Allocate an unmanaged memory block for the input and output data.
             * (The input and output are of the same length in this case, so we can use just one memory block.) */
            IntPtr ptr = fftw.malloc(n * sizeof(double));
            // Pass the managed input data to the unmanaged memory block
            Marshal.Copy(data, 0, ptr, n);
            // Plan the FFT and execute it (n/2 because complex numbers are stored as pairs of doubles)
            IntPtr plan = fftw.dft_1d(n / 2, ptr, ptr, fftw_direction.Forward, fftw_flags.Estimate);
            fftw.execute(plan);
            // Create an array to store the output values
            var fft = new double[n];
            // Pass the unmanaged output data to the managed array
            Marshal.Copy(ptr, fft, 0, n);
            // Do some cleaning
            fftw.destroy_plan(plan);
            fftw.free(ptr);
            fftw.cleanup();
            // Return the FFT output
            return fft;
        }

        /// <summary>
        /// Computes the inverse fast Fourier transform of a 1-D array of complex numbers.
        /// </summary>
        /// <param name="data">Input data.</param>
        /// <returns>Returns the normalized IFFT.</returns>
        private static double[] Ifft(double[] data)
        {
            // Get the length of the array
            int n = data.Length;
            /* Allocate an unmanaged memory block for the input and output data.
             * (The input and output are of the same length in this case, so we can use just one memory block.) */
            IntPtr ptr = fftw.malloc(n * sizeof(double));
            // Pass the managed input data to the unmanaged memory block
            Marshal.Copy(data, 0, ptr, n);
            // Plan the IFFT and execute it (n/2 because complex numbers are stored as pairs of doubles)
            IntPtr plan = fftw.dft_1d(n / 2, ptr, ptr, fftw_direction.Backward, fftw_flags.Estimate);
            fftw.execute(plan);
            // Create an array to store the output values
            var ifft = new double[n];
            // Pass the unmanaged output data to the managed array
            Marshal.Copy(ptr, ifft, 0, n);
            // Do some cleaning
            fftw.destroy_plan(plan);
            fftw.free(ptr);
            fftw.cleanup();
            // Scale the output values
            for (int i = 0, nh = n / 2; i < n; i++)
                ifft[i] /= nh;
            // Return the IFFT output
            return ifft;
        }

        /// <summary>
        /// Interlaces an array with zeros to match the FFTW convention of representing complex numbers.
        /// </summary>
        /// <param name="real">An array of real numbers.</param>
        /// <returns>Returns an array of complex numbers.</returns>
        private static double[] ToComplex(double[] real)
        {
            int n = real.Length;
            var comp = new double[n * 2];
            for (int i = 0; i < n; i++)
                comp[2 * i] = real[i];
            return comp;
        }
    }

    /// <summary>
    /// CWTFT执行结果类
    /// </summary>
    public class CWTFTModel
    {
        public double[][] result { set; get; }
        public double[] frequencies { set; get; }
    }
}
