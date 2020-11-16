using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using StoreApp.Library;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StoreApp.DataModel;
//using StoreApp.DataModel.Respositories;
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
            

            var Aaron = new StoreApp.DataModel.Customer("Aaron", "Rodgers","aaronR@email.com");
            var tom = new StoreApp.DataModel.Customer{
                FirstName = "Tom",
                LastName = "Brady'",
                Email = "tBrady@email.com"
            };

          //AddCustomer(Aaron);
          AddCustomer(tom);
            GetCustomers();
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

        static void GetCustomers()
        {
            using var context = new project0Context(_dbContext);

            var dbCustomers = context.Customers.ToList();

            var appCustomer = dbCustomers.Select(c => new StoreApp.DataModel.Customer(c.CustomerId, c.FirstName, c.LastName, c.Email)).ToList();

            foreach (var customer in appCustomer)
            {
                Console.WriteLine($"{customer.CustomerId}-{customer.FirstName}-{customer.LastName}-{customer.Email}");
            };

        }
        static void AddCustomer(StoreApp.DataModel.Customer customer)
        {
            using var context = new project0Context(_dbContext);
           
            var dbCustomer = new StoreApp.DataModel.Customer(){

              FirstName = customer.FirstName,
               LastName = customer.LastName,
                  Email = customer.Email
            };
    
           context.SaveChanges();

        }

        

    }

}
