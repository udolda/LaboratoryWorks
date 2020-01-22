using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L4_LineGraphicPatternsApp
{
    public partial class Form1 : Form
    {
        Graphics Graph;

        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            Graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Graph.Clear(BackColor);

            drawSpinRect();
        }

        private void drawSpinRect()
        {
            PointF A1 = new PointF(100, 100);
            PointF A2 = new PointF(300, 100);
            PointF A3 = new PointF(300, 300);
            PointF A4 = new PointF(100, 300);

            PointF M1, M2, M3, M4;

            Graph.DrawLine(Pens.Black, A1, A2);
            Graph.DrawLine(Pens.Black, A2, A3);
            Graph.DrawLine(Pens.Black, A3, A4);
            Graph.DrawLine(Pens.Black, A4, A1);

            for (int i = 0; i < 5; i++)
            {
                M1 = getSepPt(A1, A2, 0.25f);
                M2 = getSepPt(A2, A3, 0.25f);
                M3 = getSepPt(A3, A4, 0.25f);
                M4 = getSepPt(A4, A1, 0.25f);

                Graph.DrawLine(Pens.Black, M1, M2);
                Graph.DrawLine(Pens.Black, M2, M3);
                Graph.DrawLine(Pens.Black, M3, M4);
                Graph.DrawLine(Pens.Black, M4, M1);

                A1 = M1; A2 = M2; A3 = M3; A4 = M4;
            }
        }

        private PointF getSepPt(PointF A, PointF B, float k)
        {
            float xM = A.X + k * (B.X - A.X);
            float yM = A.Y + k * (B.Y - A.Y);

            return new PointF(xM, yM);
        }

        private void drawHatchedAngle(PointF M0, PointF M1, PointF M2)
        {
            Graph.DrawLine(Pens.Black, M1, M0);
            Graph.DrawLine(Pens.Black, M2, M0);

            PointF sp;
            List<PointF> as1 = new List<PointF>();
            List<PointF> as2 = new List<PointF>();

            #region Деление на отрезки 1 ст. угла
            sp = getSepPt(M0, M1, 0.166f);
            as1.Add(sp);//Graph.DrawEllipse(new Pen(Brushes.Red, 2), s1.X, s1.Y, 1, 1);
            sp = getSepPt(M0, M1, 0.333f);
            as1.Add(sp);//Graph.DrawEllipse(new Pen(Brushes.Red, 2), sp.X, sp.Y, 1, 1);
            sp = getSepPt(M0, M1, 0.5f);
            as1.Add(sp);//Graph.DrawEllipse(new Pen(Brushes.Red, 2), sp.X, sp.Y, 1, 1);
            sp = getSepPt(M0, M1, 0.666f);
            as1.Add(sp);//Graph.DrawEllipse(new Pen(Brushes.Red, 2), sp.X, sp.Y, 1, 1);
            sp = getSepPt(M0, M1, 0.833f);
            as1.Add(sp);//Graph.DrawEllipse(new Pen(Brushes.Red, 2), sp.X, sp.Y, 1, 1);
            #endregion

            #region Деление на отрезки 2 ст. угла
            sp = getSepPt(M0, M2, 0.166f);
            as2.Add(sp);//Graph.DrawEllipse(new Pen(Brushes.Red, 2), sp.X, sp.Y, 1, 1);
            sp = getSepPt(M0, M2, 0.333f);
            as2.Add(sp);//Graph.DrawEllipse(new Pen(Brushes.Red, 2), sp.X, sp.Y, 1, 1);
            sp = getSepPt(M0, M2, 0.5f);
            as2.Add(sp);//Graph.DrawEllipse(new Pen(Brushes.Red, 2), sp.X, sp.Y, 1, 1);
            sp = getSepPt(M0, M2, 0.666f);
            as2.Add(sp);//Graph.DrawEllipse(new Pen(Brushes.Red, 2), sp.X, sp.Y, 1, 1);
            sp = getSepPt(M0, M2, 0.833f);
            as2.Add(sp);//Graph.DrawEllipse(new Pen(Brushes.Red, 2), sp.X, sp.Y, 1, 1);
            #endregion

            for (int i = 0; i < as1.Count; i++)
            {
                Graph.DrawLine(Pens.Black, as1[i], as2[as2.Count - (i + 1)]);
            }
        }

        private void ToolStripMenuItem11a_Click(object sender, EventArgs e)
        {
            Graph.Clear(BackColor);

            drawHatchedAngle(new PointF(this.ClientSize.Width / 2, this.ClientSize.Height / 2), new PointF(this.ClientSize.Width / 2 + 10, this.ClientSize.Height / 2 - 100), new PointF(this.ClientSize.Width / 2 + 100, this.ClientSize.Height / 2 - 55));
            drawHatchedAngle(new PointF(this.ClientSize.Width / 2, this.ClientSize.Height / 2), new PointF(this.ClientSize.Width / 2 - 10, this.ClientSize.Height / 2 - 100), new PointF(this.ClientSize.Width / 2 - 100, this.ClientSize.Height / 2 - 55));

            drawHatchedAngle(new PointF(this.ClientSize.Width / 2, this.ClientSize.Height / 2), new PointF(this.ClientSize.Width / 2 + 110, this.ClientSize.Height / 2 - 45), new PointF(this.ClientSize.Width / 2 + 110, this.ClientSize.Height / 2 + 45));
            drawHatchedAngle(new PointF(this.ClientSize.Width / 2, this.ClientSize.Height / 2), new PointF(this.ClientSize.Width / 2 - 110, this.ClientSize.Height / 2 - 45), new PointF(this.ClientSize.Width / 2 - 110, this.ClientSize.Height / 2 + 45));

            drawHatchedAngle(new PointF(this.ClientSize.Width / 2, this.ClientSize.Height / 2), new PointF(this.ClientSize.Width / 2 + 10, this.ClientSize.Height / 2 + 100), new PointF(this.ClientSize.Width / 2 + 100, this.ClientSize.Height / 2 + 55));
            drawHatchedAngle(new PointF(this.ClientSize.Width / 2, this.ClientSize.Height / 2), new PointF(this.ClientSize.Width / 2 - 10, this.ClientSize.Height / 2 + 100), new PointF(this.ClientSize.Width / 2 - 100, this.ClientSize.Height / 2 + 55));
        }

        private void ToolStripMenuItem11b_Click(object sender, EventArgs e)
        {
            Graph.Clear(BackColor);

            //float tMax = (float)(2 * Math.PI);
            const float step = (float)(Math.PI / 4);
            float r = 40;
            float R = 100;
            bool bigCircle = false;
            PointF M1, M0, M2;
            float x, y;

            for (float i = 0; i < (float)(7 * Math.PI / 4); /*i += step*/)
            {
                x = (float)((this.ClientSize.Width / 2)/*x0*/+ (bigCircle ? R : r) * Math.Cos(i));
                y = (float)((this.ClientSize.Height / 2)/*y0*/- (bigCircle ? R : r) * Math.Sin(i));
                M1 = new PointF(x, y);
                bigCircle = !bigCircle;
                i += step;

                x = (float)((this.ClientSize.Width / 2)/*x0*/+ (bigCircle ? R : r) * Math.Cos(i));
                y = (float)((this.ClientSize.Height / 2)/*y0*/- (bigCircle ? R : r) * Math.Sin(i));
                M0 = new PointF(x, y);
                bigCircle = !bigCircle;
                i += step;

                x = (float)((this.ClientSize.Width / 2)/*x0*/+ (bigCircle ? R : r) * Math.Cos(i));
                y = (float)((this.ClientSize.Height / 2)/*y0*/- (bigCircle ? R : r) * Math.Sin(i));
                M2 = new PointF(x, y);

                drawHatchedAngle(M0, M1, M2);
            }

            for (float i = (float)(Math.PI / 4); i < (float)(8 * Math.PI / 4); /*i += step*/)
            {
                x = (float)((this.ClientSize.Width / 2)/*x0*/+ (bigCircle ? R : r) * Math.Cos(i));
                y = (float)((this.ClientSize.Height / 2)/*y0*/- (bigCircle ? R : r) * Math.Sin(i));
                M1 = new PointF(x, y);
                bigCircle = !bigCircle;
                i += step;

                x = (float)((this.ClientSize.Width / 2)/*x0*/+ (bigCircle ? R : r) * Math.Cos(i));
                y = (float)((this.ClientSize.Height / 2)/*y0*/- (bigCircle ? R : r) * Math.Sin(i));
                M0 = new PointF(x, y);
                bigCircle = !bigCircle;
                i += step;

                x = (float)((this.ClientSize.Width / 2)/*x0*/+ (bigCircle ? R : r) * Math.Cos(i));
                y = (float)((this.ClientSize.Height / 2)/*y0*/- (bigCircle ? R : r) * Math.Sin(i));
                M2 = new PointF(x, y);

                drawHatchedAngle(M0, M1, M2);
            }
        }

        private void drawSpinHex()
        {
            const float step = (float)(Math.PI / 3);
            float temp = 0;
            float R = 200;
            List<PointF> hexPt = new List<PointF> {new PointF(0,0), new PointF(0, 0), new PointF(0, 0), new PointF(0, 0), new PointF(0, 0), new PointF(0, 0) };//PointF M1, M2, M3, M4, M5, M6;
            List<PointF> sepPt = new List<PointF> { new PointF(0, 0), new PointF(0, 0), new PointF(0, 0), new PointF(0, 0), new PointF(0, 0), new PointF(0, 0) };
            float x, y;

            #region Нарисовали 6-уг и получили точки разделения
            x = (float)((this.ClientSize.Width / 2)/*x0*/+ R * Math.Cos(temp));
            y = (float)((this.ClientSize.Height / 2)/*y0*/- R * Math.Sin(temp));
            hexPt[0] = new PointF(x, y);
            temp += step;

            PointF M;
            for (int i = 1; i < 6; i++)
            {
                x = (float)((this.ClientSize.Width / 2)/*x0*/+ R * Math.Cos(temp));
                y = (float)((this.ClientSize.Height / 2)/*y0*/- R * Math.Sin(temp));
                hexPt[i] = new PointF(x, y);
                temp += step;
                Graph.DrawLine(Pens.Black, hexPt[i], hexPt[i - 1]);

                M = getSepPt(hexPt[(i - 1) % 6], hexPt[i], 0.333f);
                sepPt[i - 1] = M;
            }
            sepPt[5] = getSepPt(hexPt[5], hexPt[0], 0.333f);
            Graph.DrawLine(Pens.Black, hexPt[5], hexPt[0]);

            for (int i = 0; i < sepPt.Count; i++) hexPt[i] = sepPt[i];
            #endregion

            int n = 6;
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < 6; i++)
                {
                    Graph.DrawLine(Pens.Black, hexPt[i], hexPt[(i + 1) % 6]);
                    sepPt[i] = getSepPt(hexPt[i], hexPt[(i + 1) % 6], 0.333f);
                    //Graph.DrawEllipse(new Pen(Brushes.Red, 2), sepPt[i].X, sepPt[i].Y, 1, 1);
                }
                for (int i = 0; i < 6; i++) hexPt[i] = sepPt[i];
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Graph.Clear(BackColor);

            drawSpinHex();
        }
    }
}
