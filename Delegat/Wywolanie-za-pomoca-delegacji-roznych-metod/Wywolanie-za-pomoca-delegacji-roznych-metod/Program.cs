using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wywolanie_za_pomoca_delegacji_roznych_metod
{
    class Program
    {
        public static void Wyswietl1(Kontener obj)
        {
            Console.WriteLine(obj.w1);
            Console.WriteLine(obj.w2);

        }

        public static void Wyswietl2(Kontener obj)
        {
            Console.WriteLine("Wartość w1 to {0}.", obj.w1);
            Console.WriteLine("Wartość w2 to {0}.", obj.w2);
        }

        static void Main(string[] args)
        {
            Kontener k = new Kontener();
            DelegateWyswietl del1 = Wyswietl1;
            DelegateWyswietl del2 = Wyswietl2;

            k.WyswietlCallBack(del1);
            k.WyswietlCallBack(del2);

            Console.ReadKey();
        }
    }
}
