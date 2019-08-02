using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegacja_powiazana_z_wieloma_metodami
{
    public delegate void Delegacja(Kontener obj);

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

        public void WyswietlCallBack(Delegacja del)
        {
            del(this);
        }
    }
}
