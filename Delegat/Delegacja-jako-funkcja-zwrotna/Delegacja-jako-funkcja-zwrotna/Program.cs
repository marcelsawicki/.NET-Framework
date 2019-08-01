using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegacja_jako_funkcja_zwrotna
{
    class Program
    {
        public static void Wyswietl(Kontener obj)
        {
            System.Console.WriteLine(obj.w1);
            System.Console.WriteLine(obj.w2);
        }

        public static void Main(string[] args)
        {
            Kontener k = new Kontener();
            DelegateWyswietl del = Wyswietl;
            k.WyswietlCallBack(del);

            Console.ReadKey();
        }
    }
}
