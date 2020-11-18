using System;
using StoreApp.DataModel;
using StoreApp.DataModel.Repositories;
using Microsoft.EntityFrameworkCore;


namespace StoreApp.ConsoleApp
{
    public class AdminConsole

    {
        private StoreAppRepository storeRepo;


        public AdminConsole(DbContextOptions<project0Context> _dbContext)
        {
            storeRepo = new StoreAppRepository(_dbContext);
        }

        int locationId;
        public void AdminUI()
        {
            Console.WriteLine("Welcome Administrator!");
            Console.WriteLine();
            Console.WriteLine("Choose one :");
            Console.WriteLine("{A} Show All Locations");
            Console.WriteLine("{B} Show All Customers");
            Console.WriteLine("{X} Exit");
            Console.WriteLine(":");
            string input = Console.ReadLine();
            Selection(input);
        }
        public void Selection(string input)
        {
            while (input != "a" && input != "b" && input != "x")
            {
                Console.WriteLine("Choose one of the following options above:");
                input = Console.ReadLine();
            }
            switch (input.ToLower())
            {
                case "a":
                    GetAllLocations();
                    break;
                case "b":
                    GetAllCustomers();
                    break;
                case "x":
                    return;

            }


        }
        void GetAllLocations()
        {
            var locations = storeRepo.GetLocations();
            Console.WriteLine("Here are all of our locations.");
            Console.WriteLine($"Store Id\t Store Name \t\t\tAddress \t\t City\t\t State");
            Console.WriteLine();
            foreach (var location in locations)
            {
                Console.WriteLine($"{location.LocationId}\t\t{location.Name}\t{location.Address}\t\t{location.City}\t{location.State}");
            };
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("TO view the order history of a location, enter the Location's Id:");
            locationId = Int32.Parse(Console.ReadLine());
            GetOrdersByLocation();

        }
        public void GetAllCustomers()
        {
            var customers = storeRepo.GetCustomers();
            Console.WriteLine($"Customer ID\t\tFirst Name\t\tLast Name\t\tEmail");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerId}\t\t\t{customer.FirstName}\t\t\t{customer.LastName}\t\t\t{customer.Email}");
            }
        }

        public void GetOrdersByLocation()
        {
            var orders = storeRepo.GetOrdersByLocationId(locationId);
            Console.WriteLine("Here is the inventory for this location");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Order Id \tFirst Name\tLast Name\tOrdered Product \tQuantity\t\tDate");
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.OrderId}\t\t{order.Customer.FirstName}\t\t{order.Customer.LastName}\t\t{order.Product.Name}\t\t{order.OrderQuantity}\t\t{order.Date}");
            }
        }
    }

}
