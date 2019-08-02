using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprawdzian_1
{
    public delegate void Delegacja(Pojemnik obj);

    public class Pojemnik
    {
        public int Szarokosc
        {
            get
            {
                return 5;
            }
        }

        public double Wysokosc
        {
            get
            {
                return 3.5;
            }
        }

        public void ObliczPoleCallBack(Delegacja del)
        {
            del(this);
        }
    }
}
