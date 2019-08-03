using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdarzenia_generowane_przez_klase_Kontener
{
    class Program
    {
        public static void OnUjemneKomunikat()
        {
            Console.WriteLine("Przypisano ujemną wartość.");
        }

        public static void Main(string[] args)
        {
            Kontener kontener = new Kontener();
            kontener.OnUjemne += OnUjemneKomunikat;
            kontener.setX(10);
            Console.WriteLine("k.x = {0}", kontener.getX());
            kontener.setX(-10);
            Console.WriteLine("k.x = {0}", kontener.getX());

            Console.ReadKey();
        }
    }
}
