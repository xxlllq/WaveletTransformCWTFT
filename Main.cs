using SplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaveletTransformCWTFT.Wavelet;

namespace WaveletTransformCWTFT
{
    public partial class Main : Form
    {
        private static double[] arrsignal;
        public Main()
        {
            InitializeComponent();
            octaveSelect.SelectedIndex = 1;//倍频程
            sampleRateSelect.SelectedIndex = 0;//采样频率
        }

        //打开文件选择器
        private void openFile(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "文本文件(*.txt) | *.txt";
            dialog.ShowDialog();
            string filName = dialog.FileName;
            filePath.Text = filName;
            if (string.IsNullOrEmpty(filName))
                return;

            try
            {
                StreamReader sr = new StreamReader(filName, Encoding.Default);
                String line;
                var signal = new List<double>();
                //信号输入
                while ((line = sr.ReadLine()) != null)
                {
                    signal.Add(Convert.ToDouble(line));
                }
                arrsignal = signal.ToArray();
                Draw();
            }
            catch (Exception ex) {
                var sd = ex;
            }
        }

        void Draw()
        {
            SplashHandler.Start();
            SplashHandler.BringTop();
            SplashHandler.ChangeText("正在计算...");

            int sampleRate = Convert.ToInt32(sampleRateSelect.Text);
            //绘制输入信号图
            scottPlotUC1.plt.Clear();
            scottPlotUC1.plt.PlotSignal(arrsignal, sampleRate);
            scottPlotUC1.plt.XLabel("time (ms)");
            scottPlotUC1.plt.Title("输入信号", null, true, 9);
            scottPlotUC1.plt.AxisAuto();
            scottPlotUC1.Render();

            CWTFTModel data = CWTFT.Execute(arrsignal, sampleRate, Convert.ToInt32(octaveSelect.Text));

            //绘制时频图，由于数据较多，耗费时间也较多
            SplashHandler.ChangeText("计算完成，正在绘图");
            double[][] result = data.result;
            int row = result.GetLength(0), col = result[0].Length;
            double[] idxs = new double[row], yres = new double[row],  maxvals = new double[row], minvals = new double[row];

            Size sz = pictureBox1.ClientSize;
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics G = Graphics.FromImage(bmp);
            List<Color> colors = CommonUtil.GetYColorBar();
            colors.Reverse();
            for (int i = 0; i < row; i++)
            {
                idxs[i] = i;
                yres[i] = result[i][0];
                maxvals[i] = result[i].Max();
                minvals[i] = result[i].Min();
            }

            float spacewidth = sz.Width / (float)arrsignal.Count(), spaceHeight = sz.Height / (float)row;
            float minval = (float)minvals.Min(), maxval = (float)maxvals.Max(), diff = (maxval - minval) / 22;
            for (int i = 0; i < row; i++)
            {
                float spaceHeightI = spaceHeight * i;
                for (int j = 0; j < col; j++)
                {
                    int ind = (int)Math.Floor((result[i][j] - (float)minval) / diff);
                    ind = ind > 0 ? ind - 1 : 0;
                    using (SolidBrush brush = new SolidBrush(colors[ind]))
                    {
                        G.FillRectangle(brush, spacewidth * j, spaceHeightI, spacewidth, spaceHeight);
                    }
                }
            }
            // and display the result
            pictureBox1.Image = bmp;


            double[] frequencies = data.frequencies;
            scottPlotUC2.plt.Clear();
            scottPlotUC2.plt.PlotSignal(yres.Reverse().ToArray());
            scottPlotUC2.plt.Title("时间点0对应的幅值", null, true, 9);
            scottPlotUC2.plt.AxisAuto();
            scottPlotUC2.Render();


            scottPlotUC3.plt.Clear();
            scottPlotUC3.plt.PlotSignal(result.Last().ToArray());
            scottPlotUC3.plt.Title("频率" + frequencies.Last() + "对应的幅值", null, true, 9);
            scottPlotUC3.plt.AxisAuto();
            scottPlotUC3.Render();

            //时频图
            XYLinesFactory.DrawXYColorBar(pictureBox2, false);
            XYLinesFactory.DrawYColorBar(pictureBox2, minval, maxval);
            XYLinesFactory.DrawXY(xaxisPictureBox, true, false);
            XYLinesFactory.DrawXLine(xaxisPictureBox, 0, 1, 5);
            XYLinesFactory.DrawXY(yaxisPictureBox, false);
            XYLinesFactory.DrawYLine(yaxisPictureBox, (float)frequencies.Min(), (float)frequencies.Max());

            SplashHandler.Close();
        }

        /// <summary>
        /// 倍频程下拉框选中值变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void octaveSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            if (arrsignal != null && arrsignal.Any())
                Draw();
        }
    }
}
