using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace Мыльные_пузыри
{
    public partial class Form1 : Form
    {
        const int N = 200;
        int Gx, Gy;
        Graphics Graph;
        List<Bubble> Bubbles = new List<Bubble>(N);
        Random Rand;

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Graph = pictureBox1.CreateGraphics();
            Gx = pictureBox1.Width;
            Gy = pictureBox1.Height;
        }

        public Form1()
        {
            InitializeComponent();

            Gx = pictureBox1.Width;
            Gy = pictureBox1.Height;
            Graph = pictureBox1.CreateGraphics();
            timer.Interval = 1000/60;
            Rand = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bubbles.Clear();
            for (int i = 0; i < N; i++)
            {
                int rad = 5 + Rand.Next(10);
                Bubbles.Add(new Bubble(
                  rad,
                  1 + Rand.Next(3),
                  rad + Rand.Next(Gx - 2 * rad),
                  rad + Rand.Next(Gy - 2 * rad)));
            }
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Bitmap temp = new Bitmap(pictureBox1.Width, pictureBox1.Height, Graph);

            Graphics gr = Graphics.FromImage(temp);
            gr.Clear(Color.Black);
            for(int i=0; i < N; i++)
            {
                if (Bubbles[i].IsExist)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (j != i && Bubbles[j].IsExist)
                        {
                            double L = Math.Sqrt(
                                Math.Pow(Bubbles[i].X - Bubbles[j].X, 2) +
                                Math.Pow(Bubbles[i].Y - Bubbles[j].Y, 2));
                            /* если происходит касание объекта "i" с 
                             * объектом "j" большего радиуса,  
                             * то рассматриваемый объект 
                             * "i" уничтожается */
                            if (Bubbles[i].Rad + Bubbles[j].Rad + Bubbles[i].DeltRad + Bubbles[j].DeltRad >= L && Bubbles[j].Rad >= Bubbles[i].Rad)
                            {
                                Bubbles[i].IsExist = false;
                                break;
                            }
                        }
                    }
                    //при достижении края растущий объект отодвигается от этого края 
                    if (Bubbles[i].X - Bubbles[i].Rad - Bubbles[i].DeltRad <= 0) Bubbles[i].IncX();
                    if (Bubbles[i].Y - Bubbles[i].Rad - Bubbles[i].DeltRad <= 0) Bubbles[i].IncY();
                    if (Bubbles[i].X + Bubbles[i].Rad + Bubbles[i].DeltRad >= Gx) Bubbles[i].DecX();
                    if (Bubbles[i].Y + Bubbles[i].Rad + Bubbles[i].DeltRad >= Gy) Bubbles[i].DecY();

                   
                    Bubbles[i].IncRad();
                    if (2 * Bubbles[i].Rad > Gy) timer.Stop();
                    Bubbles[i].Print(gr);
                }
            }

            Graph.DrawImage(temp, new Point(0, 0));
            // увеличение размеров объектов с контролем максимального размера
        }

    }
}
