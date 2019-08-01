using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierwszaDelegacja
{
    class Program
    {
        public delegate void Delegacja();

        public static void Metoda1()
        {
            Console.WriteLine("Została wywołana Metoda1.");
        }

        public static void Metoda2(string napis)
        {
            Console.WriteLine("Została wywołana Metoda2.");
        }

        static void Main(string[] args)
        {
            Delegacja del1 = Metoda1;
            //Delegacja del2 = Metoda2;
            del1();
            //del2();
            Console.ReadKey();

        }
    }
}
