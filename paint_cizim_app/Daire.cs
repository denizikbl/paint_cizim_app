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
    internal class Daire:Sekil
    {
        private float yaricap = 0;
        public Point merkez_nokta ;
        public Brush FircaRenk
        {
            get { return firca_renk; }
            set { firca_renk = value; }
        }
        public float Yaricap
        {
            get
            {
                return yaricap;
            }
            set
            {
                yaricap = value;
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

        private void daire_bul()
        {

        }
        public bool dahil_mi(int tıkX, int tıkY)
        {                                                                                                          // seçilen noktanın merkez noktayla olan uzaklığı
            double nokta_uzaklık;                                                                                  // yarıçaptan küçük ise nokta daire içersindedir.
            nokta_uzaklık = Math.Sqrt(Math.Pow((tıkX - merkez_nokta.X), 2) + Math.Pow((tıkY - merkez_nokta.Y), 2));

            if (nokta_uzaklık > Math.Abs(yaricap))
            {
                return false;
            }
            else
                return true;
            
        }
        public override void Ciz(Graphics cizimAraci)
        {
            if (firca_renk == null)
            {
                firca_renk = new SolidBrush(Color.Black);
            }
            cizimAraci.FillEllipse(firca_renk , x, y, 2 * yaricap, 2 * yaricap);
            
            

        }
        public override string ToString()
        {
            return "Daire" + " " + x + " " + y + " " + yaricap + " " + merkez_nokta.X + " " + merkez_nokta.Y + " " + ((SolidBrush)firca_renk).Color.ToArgb();
        }
    }
}
