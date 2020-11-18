using System;
using System.Collections.Generic;
using StoreApp.DataModel;
using StoreApp.DataModel.Repositories;
using Microsoft.EntityFrameworkCore;


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

        int customerId;
        int quantity;
        int productId;
        int locationId = 1;
        decimal total;

        public void CustomerUI()
        {
            Console.WriteLine("Are You a returning customer?  y/n:");
            string input = null;
            while (input != "y" && input != "n")
            {
                Console.WriteLine("Enter 'Y' For Yes, 'N' for No :");
                input = GetUserInput().ToLower();
            }
            if (input == "n")
            {
                newUserUI();
            }
            else
            {
                oldUserUI();
            }

            try
            {
                Library.Customer customerCheck = storeRepo.GetCustomerByName(FirstName, LastName);
            }
            catch (Exception)
            {
                Console.WriteLine("There is no Customer By That Name.");
                Console.WriteLine();
                Console.WriteLine("Please Create A New User");
                newUserUI();
            }

            Library.Customer customer = storeRepo.GetCustomerByName(FirstName, LastName);
            customerId = customer.CustomerId;
            Console.Clear();
            Console.WriteLine($"Welcome\t{customer.FirstName}\t{customer.LastName}\t Email: {customer.Email}");
            Console.WriteLine();
            Console.WriteLine("Enter 'D' To Order From Default Store  or 'O' View Other Locations or 'X' to Exit: ");
            string store = GetUserInput().ToLower();
            while (store != "d" && store != "o" && store != "X")
            {
                Console.WriteLine("Enter 'D' for Default store, 'O' for Other locations or 'X' to Exit:");
                input = GetUserInput().ToLower();
            }
            if (store == "O")
            {
                GetuserLocation();
            }
            else if (store == "X")
            {
                Console.WriteLine("GoodBye!");
                return;
            }
            DataModel.Location location = storeRepo.GetLocationById(locationId);
            Console.WriteLine($"Your Store Location is \t{location.Name}\t{location.Address}\t{location.City}\t{location.State}");
            Console.WriteLine();
            Console.WriteLine("Here is the Current Inventory of This Store");
            GetInventory(locationId);
            Console.WriteLine();
            Console.WriteLine(" Enter 'o' to order an Item or Enter 'e' to Exit:");
            string userOrder = GetUserInput();
            while (userOrder != "o" && userOrder != "e")
            {
                Console.WriteLine("Enter 'o' to order an Item or Enter 'e' to Exit:");
                userOrder = GetUserInput().ToLower();
            }
            if (userOrder == "e")
            {
                Console.WriteLine($"Good Bye");
                return;
            }
            else
            {

                GetUserOrder();
            }
            bool keepOrdering = true;
            while (keepOrdering)
            {
                Console.WriteLine("Order another item? y/n:");
                string moreOrders = GetUserInput().ToLower();
                while (moreOrders != "y" && moreOrders != "n")
                {
                    Console.WriteLine("Enter 'Y' to keep ordering or 'N' to exit :");
                    moreOrders = GetUserInput().ToLower();
                }

                if (moreOrders == "y")
                {
                    GetUserOrder();
                }
                else
                {

                    GetCustomerOrder();
                    Console.WriteLine($"And your Total Price was {total}");
                    Console.WriteLine($"Good Bye");
                    keepOrdering = false;
                }

            }

        }

        public static string GetUserInput()
        {
            return Console.ReadLine();
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
            LastName = GetUserInput();
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
            Console.WriteLine("Please enter your First and Last Names.");
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
            Console.WriteLine("Here are all of our locations.");
            Console.WriteLine($"Store Id\t Store Name \t\t\tAddress \t\t City\t\t State");
            Console.WriteLine();
            foreach (var location in locations)
            {
                Console.WriteLine($"{location.LocationId}\t\t{location.Name}\t{location.Address}\t\t{location.City}\t{location.State}");
            };
            Console.WriteLine();
            Console.WriteLine("Enter the Store Id you would like to order from: ");
            locationId = Int32.Parse(GetUserInput());
        }

        public void GetInventory(int locationid)
        {
            List<DataModel.Inventory> inventories = storeRepo.GetInventoryByLocationId(locationId);
            Console.WriteLine($"Product Id\t Product Name \t\t Price \t\t Quantity In Stock");
            foreach (var inventory in inventories)
            {
                Console.WriteLine($"{inventory.ProductId}\t\t{inventory.Product.Name}\t\t{inventory.Product.Price}\t\t\t{inventory.Quantity}");
            }
        }
        public void GetUserOrder()
        {
            Console.WriteLine("Product Id:");
            productId = Int32.Parse(GetUserInput());
            Console.WriteLine("Quantity:");
            quantity = Int32.Parse(GetUserInput());
            while (quantity >= 15)
            {
                Console.WriteLine("Order Quantity is Too High, Try Again:");
                quantity = Int32.Parse(GetUserInput());
            }
            storeRepo.AddOrderByCustomerId(customerId, productId, locationId, quantity);
            Console.WriteLine("Orderd!");
        }

        public decimal GetCustomerOrder()
        {
            var customerOrders = storeRepo.GetCustomerOrders(customerId);
            Console.WriteLine("Here are all your orders: ");
            Console.WriteLine();
            Console.WriteLine($"Order Number\t\t\tProduct Name \t\t\tQuantity\t\t\t Location");
            foreach (var order in customerOrders)
            {
                Console.WriteLine($"{order.OrderId}\t\t{order.Product.Name}\t{order.OrderQuantity}\t{order.Location.Name}");
                total += (order.Product.Price * order.OrderQuantity);
            }
            return total;
        }
    }

}
