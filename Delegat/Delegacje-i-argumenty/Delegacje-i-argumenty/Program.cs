using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegacje_i_argumenty
{

    class Program
    {
        public delegate void Delegacja(string str);

        public static void Metoda1(string napis)
        {
            Console.WriteLine(napis);
        }

        static void Main(string[] args)
        {
            Delegacja del = Metoda1;
            del("To jest napis przekazany do delegacji.");

            Console.ReadKey();
        }
    }
}
