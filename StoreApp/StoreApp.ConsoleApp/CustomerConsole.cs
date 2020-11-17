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
    public class CustomerConsole

    {
        private StoreAppRepository storeRepo;


        public CustomerConsole(DbContextOptions<project0Context> _dbContext)
        {
            storeRepo = new StoreAppRepository(_dbContext);
        }

        public string FirstName;
        public string LastName;

        public string Email;

        int locationId = 1;

        public void customerUI()
        {
            Console.WriteLine("Are You a returning customer?  y/n:");
            string input = null;
            while (input != "y" && input != "n" && input != "e")
            {
                Console.WriteLine("Enter 'y' For Yes, 'n' for No or 'e' To Exit:");
                input = GetUserInput().ToLower();
            }
            if (input == "n")
            {
                newUserUI();
            }
            else if (input == "e")
            {
                Console.WriteLine("GoodBye!");
                return;
            }
            else
            {
                oldUserUI();
            }
            Library.Customer customer = storeRepo.GetCustomerByName(FirstName, LastName);
            Console.Clear();
            Console.WriteLine($"Welcome {customer.FirstName}\t{customer.LastName}");
            Console.WriteLine();
            Console.WriteLine("Enter 'd' To Order From Default Store  or 'o' View Other Locations or 'e' to Exit: ");
            string store = GetUserInput().ToLower();
            while (store != "d" && store != "o" && store != "e")
            {
                Console.WriteLine("Enter 'd' for Default store, 'o' for Other locations or 'e' to Exit:");
                input = GetUserInput().ToLower();
            }
            if (store == "o")
            {
                GetuserLocation();
            }
            else if (store == "e")
            {
                Console.WriteLine("GoodBye!");
                return;
            }

            Console.WriteLine($"Location Id is now {locationId}");
        }

        public static string GetUserInput()
        {
            return Console.ReadLine().ToLower();
        }

        public void newUserUI()
        {
            Console.WriteLine("Please enter your First Name, Last Name and Email");
            Console.WriteLine("First Name:");
            FirstName = GetUserInput();
            while (string.IsNullOrEmpty(FirstName))
            {
                Console.WriteLine("First Name can't be empty. Input your First Name");
                FirstName = GetUserInput();

            }
            Console.WriteLine("Last Name:");
            string LastName = GetUserInput();
            while (string.IsNullOrEmpty(LastName))
            {
                Console.WriteLine("Last Name can't be empty. Input your First Name");
                LastName = GetUserInput();
            }
            Console.WriteLine("Email:");
            string Email = GetUserInput();
            while (string.IsNullOrEmpty(LastName))
            {
                Console.WriteLine("Last Name can't be empty. Input your First Name");
                LastName = GetUserInput();
            }
            Library.Customer newCustomer = new Library.Customer(FirstName, LastName, Email);

            storeRepo.AddCustomer(newCustomer);

        }

        public void oldUserUI()
        {
            Console.WriteLine("Welcome Back!");
            Console.WriteLine("Please enter your First Name, Last Name and Email");
            Console.WriteLine("First Name:");
            FirstName = Console.ReadLine();
            while (string.IsNullOrEmpty(FirstName))
            {
                Console.WriteLine("First Name can't be empty. Input your First Name");
                FirstName = Console.ReadLine();

            }
            Console.WriteLine("Last Name:");
            LastName = Console.ReadLine();
            while (string.IsNullOrEmpty(LastName))
            {
                Console.WriteLine("Last Name can't be empty. Input your First Name");
                LastName = Console.ReadLine();
            }

        }

        public void GetuserLocation()
        {

            var locations = storeRepo.GetLocations();
            Console.WriteLine("Here are all our locations.");
            Console.WriteLine($"Store Id\t Store Name \t\t\tAddress \t\t City\t\t State");
            Console.WriteLine();
            foreach (var location in locations)
            {
                Console.WriteLine($"{location.LocationId}\t\t{location.Name}\t{location.Address}\t\t{location.City}\t{location.State}");
            };
            Console.WriteLine();
            Console.WriteLine("Enter the Store Id you would like to order from: ");
            locationId = Int32.Parse(Console.ReadLine());
        }
    }

}
