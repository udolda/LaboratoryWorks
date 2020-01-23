using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Graphics Gr;
        int Tab = 30;
        Brush BackBrush;
        BorderFigure borderRight, borderLeft, borderUp, borderDown;
        BallFigure ball, Sun, Earth;
        Snake snake;
        double u = 0;
        double du = Math.PI / 100;
        int R = 150;
        Point CenterPoint;
        public Form1()
        {
            InitializeComponent();
            Gr = PB.CreateGraphics();
            timer.Interval = 1000/60;
            BackBrush = new SolidBrush(PB.BackColor);
            CenterPoint = new Point(PB.Width / 2, PB.Height / 2);

        }
        private void PingPonAnimation()
        {
            borderLeft = new BorderFigure(Gr, Brushes.Black, BackBrush, new Size(30, PB.Height - 2*Tab), new Point(Tab, Tab));
            borderLeft.Print();
            borderRight = new BorderFigure(Gr, Brushes.Black, BackBrush, new Size(30, PB.Height - 2 * Tab), new Point(PB.Width - Tab - 30, Tab));
            borderRight.Print();
            ball = new BallFigure(Gr, Brushes.Yellow, BackBrush, new Size(30, 30), CenterPoint, 5, 0);
            ball.Print();
        }
        private void EarthAnimtion()
        {
            Sun = new BallFigure(Gr, Brushes.Yellow, BackBrush, new Size(50, 50), CenterPoint, 0, 0);
            Sun.Print();
            Earth = new BallFigure(Gr, Brushes.CadetBlue, BackBrush, new Size(20, 20), new Point(PB.Width / 2 + R, PB.Height / 2), 0, 0);
            Earth.Print();
        }
        private void BiliardAnimation()
        {
            borderLeft = new BorderFigure(Gr, Brushes.Black, BackBrush, new Size(30, PB.Height - 2 * Tab), new Point(Tab, Tab));
            borderLeft.Print();
            borderRight = new BorderFigure(Gr, Brushes.Black, BackBrush, new Size(30, PB.Height - 2 * Tab), new Point(PB.Width - Tab - 30, Tab));
            borderRight.Print();

            borderUp = new BorderFigure(Gr, Brushes.Black, BackBrush, new Size(PB.Width - 2 * Tab, 30), new Point( Tab, Tab));
            borderUp.Print();

            borderDown = new BorderFigure(Gr, Brushes.Black, BackBrush, new Size(PB.Width - 2 * Tab, 30), new Point(Tab, PB.Height - Tab - 30));
            borderDown.Print();

            ball = new BallFigure(Gr, Brushes.Yellow, BackBrush, new Size(30, 30), CenterPoint, 5, -5);
            ball.Print();
        }
        void SnakeAnimation()
        {
            borderLeft = new BorderFigure(Gr, Brushes.Black, BackBrush, new Size(30, PB.Height - 2 * Tab), new Point(Tab, Tab));
            borderLeft.Print();
            borderRight = new BorderFigure(Gr, Brushes.Black, BackBrush, new Size(30, PB.Height - 2 * Tab), new Point(PB.Width - Tab - 30, Tab));
            borderRight.Print();

            borderUp = new BorderFigure(Gr, Brushes.Yellow, BackBrush, new Size(PB.Width - 2 * Tab, 30), new Point(Tab, Tab));
            borderUp.Print();

            borderDown = new BorderFigure(Gr, Brushes.Yellow, BackBrush, new Size(PB.Width - 2 * Tab, 30), new Point(Tab, PB.Height - Tab - 30));
            borderDown.Print();

            snake = new Snake(Gr, Brushes.Red, BackBrush, new Size(10, 10), new Point(Tab,10), 10, 8);
            snake.Print();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (PingPongRB.Checked)
            {
                ball.Delete();
                ball.Move();
                ball.Print();
                if (ball.CheckLeftHit(borderLeft) || ball.CheckRightHit(borderRight))
                {
                    ball.Delete();
                    ball.MoveBack();
                    ball.Dx = -ball.Dx;
                }
                ball.Print();
            }
            else if (PlanetRB.Checked)
            {
                Earth.Delete();
                u -= du;
                Earth.MoveLikePlanet(CenterPoint, R, u);
                Earth.Print();
            }
            else if (BiliardRB.Checked)
            {
                ball.Delete();
                ball.Move();
                ball.Print();
                if (ball.CheckLeftHit(borderLeft) || ball.CheckRightHit(borderRight))
                {
                    ball.Delete();
                    ball.MoveBack();
                    ball.Dx = -ball.Dx;
                }
                else if (ball.CheckUpHit(borderUp) || ball.CheckDownHit(borderDown))
                {
                    ball.Delete();
                    ball.MoveBack();
                    ball.Dy = -ball.Dy;
                }
                ball.Print();

            }
            else if (SnakeRB.Checked)
            {
                snake.Move();
                if ((snake.Dx > 0 && snake.CheckRightHit(borderUp)) || (snake.Dx < 0 && snake.CheckLeftHit(borderDown))) // движемся вправо  или влево
                {
                    snake.MoveBack();
                    snake.Dy = snake.Dx;
                    snake.Dx = 0;
                }

                else if ((snake.Dy > 0 && snake.CheckDownHit(borderRight)) || (snake.Dy < 0 && snake.CheckUpHit(borderLeft))) // движемся вниз или вверх
                {
                    snake.MoveBack();
                    snake.Dx = -snake.Dy;
                    snake.Dy = 0;
                }
            }
        }

        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            Gr.Clear(PB.BackColor);
            StartStopButton.Text = "СТАРТ";
            StartStopButton.Enabled = true;
            timer.Stop();
            if (PingPongRB.Checked) PingPonAnimation();
            else if (PlanetRB.Checked) EarthAnimtion();
            else if (BiliardRB.Checked) BiliardAnimation();
            else if (SnakeRB.Checked) SnakeAnimation();
        }


        private void StartStopButton_Click(object sender, EventArgs e)
        {

            if (StartStopButton.Text == "СТАРТ")
            {
                timer.Start();
                StartStopButton.Text = "СТОП";
            }
            else
            {
                StartStopButton.Text = "СТАРТ";
                timer.Stop();
            }
        }
    }
}
