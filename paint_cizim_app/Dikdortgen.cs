using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint_cizim_app
{
    [Serializable]
    internal class Dikdortgen:Sekil
    {
        private int width = 0;
        private int height = 0;
        public int Width 
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Brush FircaRenk
        {
            get {return firca_renk;}
            set { firca_renk = value;}
        }

        public bool dahil_mi(int tıkX, int tıkY)// mouse tıklamasından gelen x-y değerlerinin dikdörtgen içersinde olup olmamasına bakar.
        {
            if (tıkX >= x && tıkY >= y && tıkX <= x + width && tıkY <= y + height)
            {
                return true;
            }
            else
                return false;

        }
        public override void Ciz(Graphics cizimAraci)
        {
            if (firca_renk == null)
            {
                firca_renk = new SolidBrush(Color.Black);
            }
            
            cizimAraci.FillRectangle(firca_renk, x, y, width, height);
         
        }
        public override string ToString()
        {
            return "Dikdortgen" + " " + x + " " + y + " " + width + " " + height + " " + ((SolidBrush)firca_renk).Color.ToArgb();
        }
    }
}
