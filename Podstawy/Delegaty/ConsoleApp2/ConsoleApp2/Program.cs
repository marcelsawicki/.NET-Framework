using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// delegacja jako funkcja zwrotna
namespace ConsoleApp2
{
    public delegate void DelegateWyswietl(Kontener obj);
    class Program
    {
        public static void Wyswietl(Kontener obj)
        {
            System.Console.WriteLine(obj.w1);
            System.Console.WriteLine(obj.w2);
        }
        static void Main(string[] args)
        {
            Kontener kontener = new Kontener();
            DelegateWyswietl del = Wyswietl;
            kontener.WyswietlCallBack(del);

            System.Console.ReadKey();
        }
    }
}
