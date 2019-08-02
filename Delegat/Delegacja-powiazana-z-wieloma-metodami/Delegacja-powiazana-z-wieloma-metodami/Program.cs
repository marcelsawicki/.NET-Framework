using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegacja_powiazana_z_wieloma_metodami
{
    class Program
    {
        public static void WyswietlW1(Kontener obj)
        {
            Console.WriteLine(obj.w1);
        }

        public static void WyswietlW2(Kontener obj)
        {
            Console.WriteLine(obj.w2);
        }

        public static void Main(string[] args)
        {
            Kontener kontener = new Kontener();
            Delegacja delegacja1 = WyswietlW1;
            Delegacja delegacja2 = WyswietlW2;

            Delegacja delegacja3 = delegacja1 + delegacja2;

            kontener.WyswietlCallBack(delegacja3);

            Console.WriteLine("------------------------------------------------------------------------");
            delegacja3 -= delegacja2;
            kontener.WyswietlCallBack(delegacja3);

            Console.WriteLine("------------------------------------------------------------------------");
            delegacja3 += delegacja2;
            kontener.WyswietlCallBack(delegacja3);

            Console.WriteLine("------------------------------------------------------------------------");
            delegacja3 += delegacja2;
            kontener.WyswietlCallBack(delegacja3);
            Console.ReadKey();

            Console.ReadKey();
        }
    }
}
