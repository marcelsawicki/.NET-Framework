using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprawdzian_1
{
    class Program
    {
        public static void PoliczPole(Pojemnik obj)
        {
            var pole = obj.Szarokosc * obj.Wysokosc;
            Console.WriteLine("Area = {0}", pole);
        }

        static void Main(string[] args)
        {
            Pojemnik pojemnik = new Pojemnik();
            Delegacja delegacja1 = PoliczPole;
            pojemnik.ObliczPoleCallBack(delegacja1);
            Console.ReadKey();
        }
    }
}
