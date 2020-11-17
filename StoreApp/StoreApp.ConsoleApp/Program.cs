using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using StoreApp.Library;
using System.Collections.Generic;
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
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Error);
            _dbContext = optionsBuilder.Options;
            
         
            StoreAppRepository storeAppRepository = new StoreAppRepository(_dbContext);

            CustomerConsole customer = new CustomerConsole(_dbContext);

            Console.WriteLine("Welcome to Discount BestBuy");
            Console.WriteLine("Where we sell the same stuff, at the same prices!!!");
            Console.WriteLine();
            customer.customerUI();
          
        //    storeAppRepository.GetLocationById(2);

        //     Console.WriteLine("Please enter your first and last names");
        //     string firstName = Console.ReadLine(); 
        //     while(string.IsNullOrEmpty(firstName)){
        //          Console.WriteLine("First Name can't be empty. Input your First Name");
        //          firstName = Console.ReadLine();  

        //     }
        //     string lastName = Console.ReadLine();
        //     while(string.IsNullOrEmpty(lastName)){
        //         Console.WriteLine("Last Name can't be empty. Input your First Name");
        //          lastName = Console.ReadLine();  
        //     }

        //     Console.WriteLine(firstName +" "+lastName);

          //  DataModel.Customer martin = new DataModel.Customer("Martin","Kyle","martink@outlook.com");
            // AddCustomer(russ);
            // GetCustomers();

           // GetCustomerOrders(martin);
          //  GetOrderById(1);
          //  GetCustomerOrders(1);
         // GetCustomers();
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
