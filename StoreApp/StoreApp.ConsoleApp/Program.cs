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
            
            
            GetCustomerByName("Aaron", "Rodgers");
           
             // GetLocations();
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

            var appCustomer = dbCustomers.Select(c => new StoreApp.Library.Customer(c.CustomerId, c.FirstName, c.LastName, c.Email)).ToList();

            foreach (var customer in appCustomer)
            {
                Console.WriteLine($"{customer.CustomerId}\t\t{customer.FirstName}\t{customer.LastName}\t{customer.Email}");
            };

        }

        static void GetCustomerByName(string firstName, string lastName){
            using var context = new project0Context(_dbContext);
            var dbCustomers = context.Customers.First(c => c.FirstName == firstName && c.LastName == lastName);
            
            var customer = new StoreApp.Library.Customer(dbCustomers.CustomerId,dbCustomers.FirstName, dbCustomers.LastName, dbCustomers.Email);
            
            Console.WriteLine($"{customer.CustomerId}\t{customer.FirstName}\t{customer.LastName}\t{customer.Email}");
        }
        //add a customer
        static void AddCustomer(StoreApp.DataModel.Customer customer)
        {
            using var context = new project0Context(_dbContext);
           
            var dbCustomer = new StoreApp.Library.Customer(){

              FirstName = customer.FirstName,
               LastName = customer.LastName,
                  Email = customer.Email
            };
    
           context.SaveChanges();

        }

        static void GetLocations()
        {

            using var context = new project0Context(_dbContext);

            var dbLocations = context.Locations.ToList();

            var appLocations = dbLocations.Select(l => new StoreApp.Library.Location(l.LocationId, l.Name, l.Address, l.City, l.State)).ToList();

                Console.WriteLine($"Store Id\t Store Name \t\t\tAddress \t\t City\t\t State");
                Console.WriteLine();
            foreach (var location in appLocations)
            {
                Console.WriteLine($"{location.LocationId}\t\t{location.Name}\t{location.Address}\t\t{location.City}\t{location.State}");
            };

        }

        static void GetOrderDetailsById(int orderId ){
              using var context = new project0Context(_dbContext);
              var dbOrders = context.Orders
              .Include( )
              
              
              .First(c => c.FirstName == firstName && c.LastName == lastName);

        }

    }

}
