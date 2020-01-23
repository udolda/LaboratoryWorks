using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComplexDynamicImApp
{
    public partial class FormMain : Form
    {
        private const double Pi = Math.PI;
        private Bitmap Waves;
        private Graphics graphics;
        //массив начальных окружностей каждого ряда волн, хранящий координаты центров окружностей для вращения
        private int[,] Circles = new int[15, 2]
        {
            {0,0},{30,30},{0,60},{30,90},{0,120},
            {30,150},{0,180},{30,210},{0,240},{30,270},
            {0,300},{30,330},{0,360},{25,390},{0,420}
        };
        //Массив углов окружностей
        private double[] Circle_Angles = new double[15];
        private ushort item = 1;

        public FormMain()
        {
            InitializeComponent();
        }

        private void волныToolStripMenuItem_Click(object sender,EventArgs e)
        {
            item = 1;
        }

        private void полётСквозьЗвёзыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            item = 2;
        }

        //Метод. Запуск анимации по нажатию кнопки.
        private void buttonDraw_Click(object sender, EventArgs e)
        {
            //присваивание значений углов в начале отрисовки
            Circle_Angles[0] = 0;
            for (int i = 1; i < 15; i++)
            {
                Circle_Angles[i] = Circle_Angles[i - 1] + (Pi / 15);
            }
            //начало отсчёта таймера
            timer1.Start();
        }

        //Метод. Выбирает рисунок и запускает отсчёт времени.
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (item)
            {
                case 1: DrawWaves(); break;

                case 2: DrawFlyTroughStars(); break;

                default:
                    {
                        MessageBox.Show("Данного пункта меню не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
            }
        }

        private void DrawWaves()
        {
            //инициализируем bitmap
            Waves = new Bitmap(Wavesbox.Width, Wavesbox.Height);
            //инициализируем графику из bitmap
            graphics = Graphics.FromImage(Waves);
            //включаем сглаживание при рисовании
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen myPen = new Pen(Color.YellowGreen, 5);
            SolidBrush Circle = new SolidBrush(Color.Black);

            graphics.Clear(Color.Black);

            //цикл отрисовки всех кружков
            for (int i = 0; i < 15; i++)
            {
                //пересчитывание координат для кружков
                double x = Circles[i, 0] - 30 * Math.Cos(Circle_Angles[i]);
                double y = Circles[i, 1] - 30 * Math.Sin(Circle_Angles[i]);
                //пересчитывание углов
                Circle_Angles[i] = Circle_Angles[i] + (Pi / 50);
                //Отрисовать начальный кружок ряда
                graphics.FillEllipse(Circle, (int)x, (int)y, 60, 60);
                graphics.DrawEllipse(myPen, (int)x, (int)y, 60, 60);
                //Если рисуем первый ряд
                if (i == 0)
                {
                    //Рисуем сначала верхний ряд(выходящий за пределы экрана), потом ниже
                    DrawCirclesTop((int)x, (int)y);
                    DrawCircles((int)x, (int)y);
                }
                //Если рисуем последний ряд
                else if (i == 14)
                {
                    //Рисуем сначала предпоследний ряд, а потом нижний(выходящий за пределы экрана)
                    DrawCircles((int)x, (int)y);
                    DrawCirclesBottom();
                }
                //Иначе рисуем все остальные ряды
                else DrawCircles((int)x, (int)y);
            }
            //Выводим содержимое на picturebox
            Wavesbox.BackgroundImage = Waves;
        }
        
        //отрисовка окружностей на рядах между первым и последним
        private void DrawCircles(int x, int y)
        {
            Pen myPen = new Pen(Color.DarkRed, 5);
            SolidBrush CircleBr = new SolidBrush(Color.Black);

            for (int i = 1; i < 10; i++)
            {
                //отрисовка каждой окружности в ряду
                graphics.FillEllipse(CircleBr, (int)x + i * 60, (int)y, 60, 60);
                graphics.DrawEllipse(myPen, (int)x + i * 60, (int)y, 60, 60);
            }
            //отрисовка окружности выходящей за пределы экрана
            graphics.FillEllipse(CircleBr, (int)x - 60, (int)y, 60, 60);
            graphics.DrawEllipse(myPen, (int)x - 60, (int)y, 60, 60);
        }

        //отрисовка окружностей в первых рядах выходящих за пределы экрана
        private void DrawCirclesTop(int x0, int y0)
        {
            Pen myPen = new Pen(Color.YellowGreen, 5);
            SolidBrush Circle = new SolidBrush(Color.Black);
            //пересчитывание координат и углов для окружностей самого верхнего ряда
            double angle = Circle_Angles[0] - (Pi / 50);
            double x = Circles[1, 0] - 30 * Math.Cos(angle);
            double y = Circles[1, 1] - 30 * Math.Sin(angle);
            //отрисовка окружности выходящей в начале за пределы экрана
            graphics.FillEllipse(Circle, (int)x, (int)y - 60, 60, 60);
            graphics.DrawEllipse(myPen, (int)x, (int)y - 60, 60, 60);

            for (int i = 1; i < 10; i++)
            {
                graphics.FillEllipse(Circle, (int)x + i * 60, (int)y - 60, 60, 60);
                graphics.DrawEllipse(myPen, (int)x + i * 60, (int)y - 60, 60, 60);
            }

            //отрисовка начальной окружности в ряду и перерисовка окружности рядом ниже
            graphics.FillEllipse(Circle, (int)x - 60, (int)y - 60, 60, 60);
            graphics.DrawEllipse(myPen, (int)x - 60, (int)y - 60, 60, 60);
            graphics.FillEllipse(Circle, (int)x0, (int)y0, 60, 60);
            graphics.DrawEllipse(myPen, (int)x0, (int)y0, 60, 60);
        }

        //отрисовка окружностей в последних рядах выходящих за пределы экрана
        private void DrawCirclesBottom()
        {
            Pen myPen = new Pen(Color.YellowGreen, 5);
            SolidBrush Circle = new SolidBrush(Color.Black);

            //пересчитывание координат и углов для окружностей самого нижнего ряда
            double angle = Circle_Angles[14] + (Pi / 50);
            double x = Circles[13, 0] - 30 * Math.Cos(angle);
            double y = Circles[13, 1] - 30 * Math.Sin(angle);
            //отрисовка окружности выходящей в начале за пределы экрана
            graphics.FillEllipse(Circle, (int)x - 60, (int)y + 60, 60, 60);
            graphics.DrawEllipse(myPen, (int)x - 60, (int)y + 60, 60, 60);

            for (int i = 1; i < 10; i++)
            {
                //отрисовка всех кружков в ряду
                graphics.FillEllipse(Circle, (int)x + i * 60, (int)y + 60, 60, 60);
                graphics.DrawEllipse(myPen, (int)x + i * 60, (int)y + 60, 60, 60);
            }

            //отрисовка начального кружка последнего ряда
            graphics.FillEllipse(Circle, (int)x, (int)y + 60, 60, 60);
            graphics.DrawEllipse(myPen, (int)x, (int)y + 60, 60, 60);
        }

        private void DrawFlyTroughStars()
        {

        }

    }
}