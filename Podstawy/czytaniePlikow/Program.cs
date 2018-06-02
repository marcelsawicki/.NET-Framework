using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static int count;
        static System.IO.StreamReader sr;
        const string name = "readme.txt";
        static void Main(string[] args)
        {
            count = 0;
            try
            {
                sr = new System.IO.StreamReader(name);
                readLines();
                System.Console.WriteLine("Liczba linii: {0}\n", count);
            }
            catch(Exception e)
            {
                Console.WriteLine("Brak pliku: " + name + "\n");
            }
            Console.ReadLine();
        }
        static void readLines()
        {
            String textLine = sr.ReadLine();
            if(textLine!=null)
            {
                System.Console.WriteLine(textLine);
                count++;
                readLines();
            }
        }
    }
}
