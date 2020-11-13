using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using StoreApp.Library;
using System.Collections.Generic;


namespace StoreApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Store discount = new Store();
            discount.Name = "Discount BuestBuy";
            Store home = new Store();
            home.Name = "Discount BuestBuy";
            //    Location atlanta = new Location("Atlanta");
            //    Location kennesaw = new Location("kennesaw");
            //    Location marietta = new Location("marietta");
            //    Location mableton = new Location("mableton");
            discount.addLocations("atlanta");
            discount.addLocations("Kennesaw");
            discount.addLocations("marietta");
            home.addLocations("atlanta");
            home.addLocations("Kennesaw");
            home.addLocations("marietta");



            Console.WriteLine($"Welcome to {discount.Name}!");
            string input;
            do
            {
                Console.WriteLine($"To see all of our locations,  Enter 'r' to read all of our locations or 'q' to exit");
                input = Console.ReadLine().ToLower();
            } while (input != "r" && input != "q");

            if (input == "r")
            
            {
                int locationIndex = 1;
                var locations = discount.getLocations();
                foreach (string location in locations)
                {
                    Console.WriteLine($"{locationIndex} - {location}");
                    locationIndex++;
                }
            };

        }
    }

}
