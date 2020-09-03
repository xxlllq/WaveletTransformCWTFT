using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveletTransformCWTFT.Wavelet
{
    public class XYLinesFactory
    {
        #region   画出X轴与Y轴
        /// <summary>
        /// 在任意的panel里画一个坐标，坐标所在的四边形距离panel边50像素
        /// </summary>
        /// <param name="pan"></param>
        public static void DrawXYColorBar(PictureBox pictureBox,bool flagx  = true,bool flagy =true)
        {
            Size sz = pictureBox.ClientSize;
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics g = Graphics.FromImage(bmp);
            if (flagx)
            {
                //绘制X轴,
                PointF px1 = new PointF(0, 0);
                PointF px2 = new PointF(pictureBox.Width, 0);
                g.DrawLine(new Pen(Brushes.Black, 2), px1, px2);
            }
            if (flagy)
            {
                float newY = pictureBox.Height - 25;
                //绘制Y轴
                PointF py1 = new PointF(25, 25);
                PointF py2 = new PointF(25, newY);
                g.DrawLine(new Pen(Brushes.Black, 2), py1, py2);
            }
            pictureBox.Image = bmp;
        }

        public static void DrawXY(PictureBox pictureBox, bool flagx = true, bool flagy = true)
        {
            Size sz = pictureBox.ClientSize;
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics g = Graphics.FromImage(bmp);
            if (flagx)
            {
                //绘制X轴,
                PointF px1 = new PointF(0, 0);
                PointF px2 = new PointF(pictureBox.Width, 0);
                g.DrawLine(new Pen(Brushes.Black, 2), px1, px2);
            }
            if (flagy)
            {
                //绘制Y轴
                PointF py1 = new PointF(pictureBox.Width, 0);
                PointF py2 = new PointF(pictureBox.Width, pictureBox.Height);
                g.DrawLine(new Pen(Brushes.Black, 2), py1, py2);
            }

            pictureBox.Image = bmp;
        }
        #endregion

        /// <summary>
        /// 画出Y轴上的分值线，从任意值开始
        /// </summary>
        /// <param name="pan"></param>
        /// <param name="minY"></param>
        /// <param name="maxY"></param>
        /// <param name="len"></param>
        #region   画出Y轴上的分值线，从任意值开始
        public static void DrawYColorBar(PictureBox pictureBox, float minY, float maxY, int len = 22)
        {
            List<Color> colors = CommonUtil.GetYColorBar();
            float move = 45f;
            float LenX = pictureBox.Width - 2 * move;
            float LenY = pictureBox.Height - 2 * move;
            Size sz = pictureBox.ClientSize;
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i <= len; i++)    //len等份Y轴
            {
                PointF px1 = new PointF(move, LenY * i / len + move);
                PointF px2 = new PointF(move + 4, LenY * i / len + move);
                string sx = RoundToSignificantDigits(maxY - (maxY - minY) * i / len, 3)+"";
                g.DrawLine(new Pen(Brushes.Black, 2), px1, px2);
                if (i != len)
                {
                    SolidBrush myBrush = new SolidBrush(colors[i]);
                    g.FillRectangle(myBrush, new Rectangle((int)px1.X, (int)px1.Y, 30, 12));
                }

                if (i % 4 == 0)
                {
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Far;
                    drawFormat.LineAlignment = StringAlignment.Center;
                    g.DrawString(sx, new Font("宋体", 8f), Brushes.Black, new PointF(move, LenY * i / len + move * 1.1f), drawFormat);
                }
            }
            pictureBox.Image = bmp;
        }

        public static void DrawYLine(PictureBox yaxisPictureBox, float minY, float maxY, int len = 22)
        {
            List<Color> colors = CommonUtil.GetYColorBar();
            float move = 35f;
            Size sz = yaxisPictureBox.ClientSize;
            float LenX = sz.Width;
            float LenY = sz.Height;
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics g= Graphics.FromImage(bmp);
            for (int i = 0; i <= len; i += 4)    //len等份Y轴
            {
                PointF px1 = new PointF(LenX, LenY * i / len);
                PointF px2 = new PointF(LenX - 5, LenY * i / len);
                g.DrawLine(new Pen(Brushes.Black, 2), px1, px2);
                string sx = RoundToSignificantDigits(maxY - (maxY - minY) * i / len, 2) + "";
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Far;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(sx, new Font("宋体", 8f), Brushes.Black, new PointF(move, LenY * i / len + 5), drawFormat);
            }
            yaxisPictureBox.Image = bmp;
        }

        #endregion

        #region   画出X轴上的分值线，从任意值开始
        /// <summary>
        /// 画出X轴上的分值线，从任意值开始
        /// </summary>
        /// <param name="pan"></param>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <param name="len"></param>
        public static void DrawXLine(PictureBox pictureBox, float minX, float maxX, int len)
        {
            float move = 25f;
            Size sz = pictureBox.ClientSize;
            float LenX = sz.Width;
            float LenY = sz.Height;
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i <= len; i++)
            {
                PointF py1 = new PointF(LenX * i / len, pictureBox.Height - move - 4);
                PointF py2 = new PointF(LenX * i / len, pictureBox.Height - move);
                string sy = ((maxX - minX) * i / len + minX).ToString();
                g.DrawLine(new Pen(Brushes.Black, 2), py1, py2);
                if (i == len)
                    g.DrawString(sy, new Font("宋体", 8f), Brushes.Black, new PointF(LenX * i / len - 10, pictureBox.Height - move / 1.1f));
                else
                    g.DrawString(sy, new Font("宋体", 8f), Brushes.Black, new PointF(LenX * i / len , pictureBox.Height - move / 1.1f));
            }
            pictureBox.Image = bmp;
        }

        #endregion

        public static double RoundToSignificantDigits(double d, int digits)
        {
            if (d == 0)
                return 0;

            double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
            return scale * Math.Round(d / scale, digits);
        }
    }
}
