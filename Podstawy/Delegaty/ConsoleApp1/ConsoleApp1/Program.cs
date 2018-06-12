using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public delegate void Delegacja();
        public static void MetodaDelegowana()
        {
            Console.WriteLine("Zostala wywolana MetodaDelegowana.");
        }

        static void Main(string[] args)
        {
            Delegacja delegacja = MetodaDelegowana;
            delegacja();

            Console.ReadKey();
        }
    }
}
