using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveletTransformCWTFT.Wavelet
{
    /// <summary>
    /// 公共工具类
    /// </summary>
    public class CommonUtil
    {
        /// <summary>
        /// 渐变颜色
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="steps"></param>
        /// <returns></returns>
        public static IEnumerable<Color> GetGradients(Color start, Color end, int steps)
        {
            int stepsp = steps - 1;
            int stepA = (end.A - start.A) / stepsp;
            int stepR = (end.R - start.R) / stepsp;
            int stepG = (end.G - start.G) / stepsp;
            int stepB = (end.B - start.B) / stepsp;

            for (int i = 0; i < steps; i++)
            {
                yield return Color.FromArgb(start.A + (stepA * i),
                                            start.R + (stepR * i),
                                            start.G + (stepG * i),
                                            start.B + (stepB * i));
            }
        }


        public static List<Color> GetYColorBar()
        {
            return new List<Color>() {
                Color.FromArgb(251,50,50),
                Color.FromArgb(244,127,0),
                Color.FromArgb(244,183,0),
                Color.FromArgb(234,218,2),
                Color.FromArgb(251,251,68),
                Color.FromArgb(229,241,17),
                Color.FromArgb(193,231,17),
                Color.FromArgb(149,221,42),
                Color.FromArgb(50,231,17),
                Color.FromArgb(0,216,55),
                Color.FromArgb(0,195,70),
                Color.FromArgb(0,188,111),
                Color.FromArgb(0,195,149),
                Color.FromArgb(0,213,200),
                Color.FromArgb(0,223,254),
                Color.FromArgb(0,188,254),
                Color.FromArgb(0,155,254),
                Color.FromArgb(0,119,254),
                Color.FromArgb(0,86,254),
                Color.FromArgb(0,37,254),
                Color.FromArgb(0,37,185),
                Color.FromArgb(0,37,137)
            };
        }
    }
}
