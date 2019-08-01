using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegacja_jako_funkcja_zwrotna
{
    public delegate void DelegateWyswietl(Kontener obj);

    public class Kontener
    {
        public int w1
        {
            get
            {
                return 100;
            }
        }

        public double w2
        {
            get
            {
                return 2.14;
            }
        }

        public void WyswietlCallBack(DelegateWyswietl del)
        {
            del(this);
        }
    }
}
