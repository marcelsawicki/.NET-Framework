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
            int wynik = argument1 + argument2;
            return wynik;
        }

        static void Main(string[] args)
        {
            Delegacja del = Dodaj;
            int wartosc = del(4, 8);
            Console.WriteLine("Wynikiem jest {0}.", wartosc);

            Console.ReadKey();
        }
    }
}
