using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zawracanie_wartosci_przez_delegacje
{
    class Program
    {
        public delegate int Delegacja(int arg1, int arg2);

        public static int Dodaj(int argument1, int argument2)
        {
            return 0;
        }

        static void Main(string[] args)
        {
        }
    }
}
