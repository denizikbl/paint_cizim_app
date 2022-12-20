using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint_cizim_app
{
    [Serializable]
    internal abstract class Sekil
    {
        protected int x;
        protected int y;
        protected Brush firca_renk ;

        public abstract void Ciz(Graphics cizimaraci);
    }
}
