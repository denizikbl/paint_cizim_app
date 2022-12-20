using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint_cizim_app
{
    internal class Islemler
    {
        protected int x;
        protected int y;
        protected int sekil_onceki_X;
        protected int sekil_onceki_Y;

        public virtual void tasima(int x, int y, int mesafeX, int mesafeY)
        {
            x = sekil_onceki_X + mesafeX;
            y = sekil_onceki_Y + mesafeY;
            this.x = x;
            this.y = y;

        }
        public int X
        {
            get{ return x; }
            set { x = value; }
        }
        public int Sekil_onceki_X

        {
            get { return sekil_onceki_X; }
            set { sekil_onceki_X = value; }
        }
        public int Sekil_onceki_Y
        {
            get { return sekil_onceki_Y; }
            set { sekil_onceki_Y = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
