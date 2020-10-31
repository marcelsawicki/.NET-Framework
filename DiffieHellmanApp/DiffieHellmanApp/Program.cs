using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DiffieHellman diffieHellman = new DiffieHellman();
            List<int> lista = new List<int>();

            lista = diffieHellman.GetKeys(19, 2, 6, 13);
        }
    }
}
