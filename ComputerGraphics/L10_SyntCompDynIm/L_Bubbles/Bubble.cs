using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Мыльные_пузыри
{
    class Bubble
    {
        public bool IsExist;

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Rad { get; private set; }
        public int DeltRad { get; }

        public Bubble(int rad,int dRad, int x, int y)
        {
            this.Rad = rad;
            this.DeltRad = dRad;
            this.X = x;
            this.Y = y;
            IsExist = true;
        }

        public void Print(Graphics gr)
        {
            gr.DrawEllipse(new Pen(Color.Yellow, 2), X - Rad, Y - Rad, Rad * 2, 2 * Rad);
        }

        public void IncX()
        {
            X += DeltRad;
        }

        public void IncY()
        {
            Y += DeltRad;
        }

        public void DecX()
        {
            X -= DeltRad;
        }
        public void DecY()
        {
            Y -= DeltRad;
        }
        public void IncRad()
        {
            Rad += DeltRad;
        }

    }
}
