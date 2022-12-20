using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace paint_cizim_app
{
    [Serializable]
    internal class Ucgen:Sekil
    {
        int mesafeX;
        int mesafeY;
        int cizim_AlaniWidth;
        int cizim_AlaniHeight;
        public Brush FircaRenk
        {
            get { return firca_renk; }
            set { firca_renk = value; }

        }
        Point[] UcgenPoint = new Point[3];
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
        public int MESAFEX
        {
            get { return mesafeX; }
            set { mesafeX = value; }

        }
        public int MESAFEY
        {
            get { return mesafeY; }
            set { mesafeY = value; }

        }
        public int CIZIM_ALANIWIDTH
        {
            get { return cizim_AlaniWidth; }
            set { cizim_AlaniWidth = value; }

        }
        public int CIZIM_ALANIHEIGHT
        {
            get { return cizim_AlaniHeight; }
            set { cizim_AlaniHeight = value; }

        }

        private void Ucgen_pointBul()
        {
           
            if (UcgenPoint[1].X > 0 && UcgenPoint[0].Y > 0 && UcgenPoint[2].Y < cizim_AlaniHeight && UcgenPoint[2].X < cizim_AlaniWidth)
            {
                UcgenPoint[0].X = x;
                UcgenPoint[0].Y = y - (2 * mesafeY);
                UcgenPoint[1].X = x - mesafeX;
                UcgenPoint[2].X = 2 * UcgenPoint[0].X - UcgenPoint[1].X;
                UcgenPoint[2].Y = UcgenPoint[0].Y + 3 * mesafeY;
                UcgenPoint[1].Y = UcgenPoint[2].Y;
                
            }
            else if (y - (2 * mesafeY) > 0 && x - mesafeX > 0 && x + mesafeX < cizim_AlaniWidth && y + mesafeY < cizim_AlaniHeight)
            {
                UcgenPoint[0].X = x;
                UcgenPoint[0].Y = y - (2 * mesafeY);
                UcgenPoint[1].X = x - mesafeX;
                UcgenPoint[2].X = 2 * UcgenPoint[0].X - UcgenPoint[1].X;
                UcgenPoint[2].Y = UcgenPoint[0].Y + 3 * mesafeY;
                UcgenPoint[1].Y = UcgenPoint[2].Y;
            }
            else
            {
                if (UcgenPoint[1].X <= 0 && UcgenPoint[0].Y < 0)
                {
                    UcgenPoint[1].X = 0;
                }
                if (UcgenPoint[0].Y <= 0 && UcgenPoint[1].X < 0)
                {
                    UcgenPoint[0].Y = 0;
                }
                if (x - mesafeX > 0 && UcgenPoint[0].Y > 0 && UcgenPoint[2].X < cizim_AlaniWidth && UcgenPoint[2].Y < cizim_AlaniHeight)
                {
                    UcgenPoint[1].X = x - mesafeX;
                }
                if (y - (2 * mesafeY) > 0 && x - mesafeX > 0 && UcgenPoint[2].X < cizim_AlaniWidth && UcgenPoint[2].Y < cizim_AlaniHeight)
                {
                    UcgenPoint[0].Y = y - (2 * mesafeY);
                }
                if (UcgenPoint[0].Y != 0 && UcgenPoint[1].X > 0 && UcgenPoint[0].Y < 0 && UcgenPoint[2].X < cizim_AlaniWidth && UcgenPoint[2].Y < cizim_AlaniHeight)
                {
                    UcgenPoint[1].Y = UcgenPoint[0].Y + 3 * mesafeY;
                }
                if (UcgenPoint[2].X > cizim_AlaniWidth)
                {
                    UcgenPoint[2].X = cizim_AlaniWidth;
                }
                if (UcgenPoint[2].X <= cizim_AlaniWidth && UcgenPoint[0].Y < 0 && UcgenPoint[1].Y < cizim_AlaniHeight && UcgenPoint[2].X < cizim_AlaniWidth)
                {
                    UcgenPoint[2].X = 2 * UcgenPoint[0].X - UcgenPoint[1].X;
                }

                UcgenPoint[0].X = x;
                //UcgenPoint[2].Y = UcgenPoint[1].Y;
                UcgenPoint[1].Y = UcgenPoint[2].Y;

            }
            
        }
        public bool Dahil_mi(int tıkX, int tıkY)
        {
            int m, c;
            Boolean icerde= false;
            if (tıkY < UcgenPoint[0].Y || tıkY > UcgenPoint[1].Y || tıkX < UcgenPoint[1].X || tıkX > UcgenPoint[2].X)
            {
                icerde = false;
            }
            else
            {
                if (tıkX <= UcgenPoint[0].X && tıkY <= UcgenPoint[1].Y)
                {
                    m = (UcgenPoint[0].Y - UcgenPoint[1].Y) / (UcgenPoint[0].X - UcgenPoint[1].X);
                    c = UcgenPoint[0].Y - m * UcgenPoint[0].X;
                    if (tıkY >= m * tıkX + c)
                    {
                        icerde= true;   
                        return icerde;
                    }
                    else
                    {
                        icerde = false;
                        return icerde;
                    }
                }
                else if (tıkX >= UcgenPoint[0].X && tıkY <= UcgenPoint[2].Y)
                {
                    m = (UcgenPoint[0].Y - UcgenPoint[2].Y) / (UcgenPoint[0].X - UcgenPoint[2].X);
                    c = UcgenPoint[0].Y - m * UcgenPoint[0].X;
                    if (tıkY >= m * tıkX + c)
                    {
                        icerde = true;
                        return icerde;
                    }
                    else
                    {
                        icerde = false;
                        return icerde;
                    }

                }
                
            }
            
            return icerde;
        }
        public override void Ciz(Graphics cizimaraci)
        {
            Ucgen_pointBul();
            if (firca_renk == null)
            {
                firca_renk = new SolidBrush(Color.Black);
            }
            cizimaraci.FillPolygon(firca_renk, UcgenPoint);

        }
        public override string ToString()
        {
            return "Ucgen" + " " + x + " " + y + " " + mesafeX + " " + mesafeY + " " + cizim_AlaniHeight + " " + cizim_AlaniWidth + " " + ((SolidBrush)firca_renk).Color.ToArgb();
        }
    }
}
