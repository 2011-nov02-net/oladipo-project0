using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using StoreApp.Library;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StoreApp.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace StoreApp.ConsoleApp
{
    class Program
    {
        static DbContextOptions<project0Context> s_dbContextOptions;
        static void Main(string[] args)
        {
            using var logStream = new StreamWriter("db-log.txt");
            var optionsBuilder = new DbContextOptionsBuilder<project0Context>();
            optionsBuilder.UseSqlServer(GetConnectionString());
            optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Error);
            s_dbContextOptions = optionsBuilder.Options;


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

        static string GetConnectionString()
        {
            string path = "../../../project0.connection-string.json";
            string json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch (IOException)
            {
                Console.WriteLine($"required file {path} not found. should just be the connection string in quotes.");
                throw;
            }
            string connectionString = JsonSerializer.Deserialize<string>(json);
            return connectionString;
        }
    }

}
