using System;
using System.IO;
using System.Text.Json;
using StoreApp.DataModel;
using StoreApp.DataModel.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace StoreApp.ConsoleApp
{
    class Program
    {
        static DbContextOptions<project0Context> _dbContext;
        static void Main(string[] args)
        {
            using var logStream = new StreamWriter("ef-log.txt");
            var optionsBuilder = new DbContextOptionsBuilder<project0Context>();
            optionsBuilder.UseSqlServer(GetConnectionString());
            optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information);
            _dbContext = optionsBuilder.Options;


            StoreAppRepository storeAppRepository = new StoreAppRepository(_dbContext);

            CustomerConsole customer = new CustomerConsole(_dbContext);
            AdminConsole admin = new AdminConsole(_dbContext);

            Console.WriteLine("Welcome to Discount BestBuy");
            Console.WriteLine("Where we sell the same stuff, at the same prices!!!");
            Console.WriteLine();
            Console.WriteLine("Enter 'A' for Admin or 'C' For Customer:");
            string input = Console.ReadLine().ToLower();
            while (input != "a" && input != "c")
            {
                Console.WriteLine("Enter 'A' for Admin or 'C' For Customer:");
                input = Console.ReadLine().ToLower();
            }
            if (input == "a")
            {
                admin.AdminUI();
            }
            else customer.CustomerUI();

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
