using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp1.Classes
{
    interface IPrint
    {
        /// <summary>
        /// Нарисовать фигуру
        /// </summary>
        void Print();
        /// <summary>
        /// Удаление фигуры(закрашивание её цветом фона)
        /// </summary>
        void Delete();
    }
    interface IMove
    {
        /// <summary>
        /// перемещение фигуры на Dx Dy
        /// </summary>
        void Move();
        /// <summary>
        /// перемещение фигуры на -Dx -Dy
        /// </summary>
        void MoveBack();
    }
    interface ICheckBorderHit
    {
        /// <summary>
        /// проверить столкновение справа
        /// </summary>
        /// <param name="borderRight">Стенка справа</param>
        /// <returns></returns>
        bool CheckRightHit(BorderFigure borderRight);
        /// <summary>
        /// проверить столкновение слева
        /// </summary>
        /// <param name="borderLeft">Стенка слева</param>
        /// <returns></returns>
        bool CheckLeftHit(BorderFigure borderLeft);
        bool CheckUpHit(BorderFigure borderUp);
        bool CheckDownHit(BorderFigure borderDown);
    }
    abstract class BaseFigure 
    {
        public readonly Size size;
        protected Graphics gr;
        public int Dx, Dy;
        protected Brush brush;
        protected Brush backColor;

        public  Point UpLeftPoint
        {
            get;
            internal set;
        }

        public BaseFigure(Graphics Graphics, Brush Brush, Brush BackColor, Size Size) 
        {
            size = Size;
            gr = Graphics;
            brush = Brush;
            backColor = BackColor;
        }
      


    }
    class BallFigure : BaseFigure, IMove, IPrint, ICheckBorderHit
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="brush">Цвет фигуры</param>
        /// <param name="BackColor">Цвет фона</param>
        /// <param name="Size">Размер фигуры</param>
        /// <param name="CenterPoint">Центральная точка</param>
        /// <param name="Dx">Смещение по Х</param>
        /// <param name="Dy">Смещение по Y</param>
        public BallFigure(Graphics Gr, Brush brush, Brush BackColor, Size Size, Point CenterPoint, int Dx, int Dy) : base(Gr, brush, BackColor, Size)
        {
            this.Dx = Dx;
            this.Dy = Dy;
            UpLeftPoint = new Point(CenterPoint.X - size.Width / 2, CenterPoint.Y - size.Height / 2);
        }

        public void MoveLikePlanet(Point Center, int R, double u)
        {
            int x = (int)(Center.X + R * Math.Cos(u));
            int y = (int)(Center.Y + R * Math.Sin(u));
            UpLeftPoint = new Point(x - size.Width / 2, y - size.Height / 2);
        }
        
        /*
        
        public void ChangeDxDirection(int newDx)
        {
            Dx = newDx;
        }

        public void ChangeDyDirection(int newDy)
        {
            Dy = newDy;
        }
        */
        public void Move()
        {
            UpLeftPoint = new Point(UpLeftPoint.X + Dx, UpLeftPoint.Y + Dy);
        }

        public void MoveBack()
        {
            UpLeftPoint = new Point(UpLeftPoint.X - Dx, UpLeftPoint.Y - Dy);
        }
        public void Delete()
        {
            gr.FillEllipse(backColor, new Rectangle(UpLeftPoint, size));
        }

        public void Print()
        {
            gr.FillEllipse(brush, new Rectangle(UpLeftPoint, size));
        }

        public bool CheckRightHit(BorderFigure borderRight)
        {
            if (UpLeftPoint.X + size.Width >= borderRight.UpLeftPoint.X) return true;
            else return false;

        }

        public bool CheckLeftHit(BorderFigure borderLeft)
        {
            if (UpLeftPoint.X <= borderLeft.UpLeftPoint.X + borderLeft.size.Width) return true;
            else return false;
        }

        public bool CheckUpHit(BorderFigure borderUp)
        {
            if (UpLeftPoint.Y <= borderUp.UpLeftPoint.Y + borderUp.size.Height) return true;
            else return false;
        }

        public bool CheckDownHit(BorderFigure borderDown)
        {
            if (UpLeftPoint.Y + size.Height >= borderDown.UpLeftPoint.Y) return true;
            else return false;
        }
    }
    class BorderFigure : BaseFigure, IPrint
    {
        public BorderFigure(Graphics Gr, Brush brush, Brush BackColor, Size Size, Point UpLeftPoint) : base(Gr, brush, BackColor, Size)
        {
            this.UpLeftPoint = UpLeftPoint;
        }

        public void Delete()
        {
            gr.FillRectangle(backColor, new Rectangle(UpLeftPoint, size));
        }

        public void Print()
        {
            gr.FillRectangle(brush, new Rectangle(UpLeftPoint, size));
        }
    }
    class SquareFigure : BaseFigure, IPrint,IMove,ICheckBorderHit
    {
        private int tab;
        public SquareFigure(Graphics Gr, Brush brush, Brush BackColor, Size Size, Point UpLeftPoint, int Dx, int Dy, int Tab) : base(Gr, brush, BackColor, Size)
        {
            this.Dx = Dx;
            this.Dy = Dy;
            this.UpLeftPoint = UpLeftPoint;
            tab = Tab;
        }
        public SquareFigure(SquareFigure fig):this(fig.gr,fig.brush,fig.backColor,fig.size,fig.UpLeftPoint,fig.Dx,fig.Dy,fig.tab)
        {
        }
        public void Move()
        {
            UpLeftPoint = new Point(UpLeftPoint.X + Dx, UpLeftPoint.Y + Dy);
        }

        public void MoveBack()
        {
            UpLeftPoint = new Point(UpLeftPoint.X - Dx, UpLeftPoint.Y - Dy);
        }
        public void Delete()
        {
            gr.FillRectangle(backColor, new Rectangle(UpLeftPoint, size));
        }

        public void Print()
        {
            gr.FillRectangle(brush, new Rectangle(UpLeftPoint, size));
        }

        public bool CheckRightHit(BorderFigure borderUp)
        {
            if (UpLeftPoint.X > borderUp.UpLeftPoint.X + borderUp.size.Width + tab) return true;
            else return false;

        }

        public bool CheckLeftHit(BorderFigure borderDown)
        {
            if (UpLeftPoint.X + size.Width < borderDown.UpLeftPoint.X - tab) return true;
            else return false;
        }

        public bool CheckUpHit(BorderFigure borderLeft)
        {
            if (UpLeftPoint.Y + size.Height < borderLeft.UpLeftPoint.Y - tab) return true;
            else return false;
        }

        public bool CheckDownHit(BorderFigure borderRight)
        {
            if (UpLeftPoint.Y > borderRight.UpLeftPoint.Y + borderRight.size.Height + tab) return true;
            else return false;
        }
    }
    class Snake:IPrint, IMove, ICheckBorderHit
    {
        SquareFigure[] snake;
        int n, ind_first, ind_last;
        public int Dx, Dy;
        public Snake(Graphics Gr, Brush brush, Brush BackColor, Size Size, Point UpLeftPoint, int Tab, int N)
        {
            this.Dx = Size.Width;
            this.Dy = 0;
            n = N;
            snake = new SquareFigure[n];
            for (int i = 0; i < n; i++)
            {
                snake[i] = new SquareFigure(Gr, brush, BackColor, Size, new Point(UpLeftPoint.X + i*Size.Width,UpLeftPoint.Y), Dx, Dy, Tab);
            }
            ind_first = n - 1;
            ind_last = 0;
        }
        public bool CheckDownHit(BorderFigure borderRight)
        {
            return (snake[ind_first].CheckDownHit(borderRight));
        }

        public bool CheckLeftHit(BorderFigure borderDown)
        {
            return (snake[ind_first].CheckLeftHit(borderDown));
        }

        public bool CheckRightHit(BorderFigure borderUp)
        {
            return (snake[ind_first].CheckRightHit(borderUp));
        }

        public bool CheckUpHit(BorderFigure borderLeft)
        {
            return (snake[ind_first].CheckUpHit(borderLeft));
        }

        public void Delete()
        {
            foreach (var item in snake)
            {
                item.Delete();
            }
        }

        public void Move()
        {
            snake[ind_last].Delete();
            snake[ind_last].UpLeftPoint = new Point(snake[ind_first].UpLeftPoint.X + Dx, snake[ind_first].UpLeftPoint.Y + Dy);

            ind_first = ind_last;
            ind_last = (ind_last + 1) % n;

            snake[ind_first].Print();
        }

        public void MoveBack()
        {
            snake[ind_first].Delete();
            snake[ind_first].UpLeftPoint = new Point(snake[ind_last].UpLeftPoint.X - Dx, snake[ind_last].UpLeftPoint.Y - Dy);

            ind_last = ind_first;
            ind_first = (ind_first - 1 + n) % n;

            snake[ind_last].Print();
        }

        public void Print()
        {
            foreach (var item in snake)
            {
                item.Print();
            }
        }
    }
}
