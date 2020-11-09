using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using StoreApp;

namespace StoreApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetProducts();
        }

        static List<Product> GetProducts(){
            var numbers = new int[5];

            numbers[3] = 1;
            return null;
        }
    }
}
