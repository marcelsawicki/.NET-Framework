using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdarzenia_generowane_przez_klase_Kontener
{
    public delegate void OnUjemneEventDelegate();
    public class Kontener
    {
        private int x;
        public event OnUjemneEventDelegate OnUjemne;

        public int getX()
        {
            return x;
        }

        public void setX(int arg)
        {
            x = arg;
            if (arg < 0)
            {
                if (OnUjemne != null)
                {
                    OnUjemne();
                }
            }
        }
    }
}
