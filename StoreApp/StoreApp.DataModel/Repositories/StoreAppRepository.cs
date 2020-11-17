using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
//using StoreApp.DataModel.Entities;
using StoreApp.Library;

namespace StoreApp.DataModel.Repositories
{
    public class StoreAppRepository 
    {
        private readonly DbContextOptions<project0Context> _dbContext;

        // private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        public StoreAppRepository(DbContextOptions<project0Context> dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Library.Location> GetLocations()
        {

           using var context = new project0Context(_dbContext);

            var dbLocations = context.Locations.ToList();

            var appLocations = dbLocations.Select(l => new StoreApp.Library.Location(l.LocationId, l.Name, l.Address, l.City, l.State)).ToList();

            return appLocations;
        }

          public DataModel.Location GetLocationById(int locationId)
        {
            using var context = new project0Context(_dbContext);

            var dbLocation = context.Locations
            .Include(i => i.Inventories)
            .ThenInclude(li => li.Product)
            .First(l => l.LocationId == locationId);
    
         //   Console.WriteLine($"{dbLocation.LocationId}\t{dbLocation.Name}\t{dbLocation.Address}");
            return dbLocation;
        }
        public List<Library.Customer> GetCustomers()
        {
            using var context = new project0Context(_dbContext);

            var dbCustomers = context.Customers.ToList();

            var appCustomer = dbCustomers.Select(c => new StoreApp.Library.Customer(c.CustomerId, c.FirstName, c.LastName, c.Email)).ToList();
            
            var customers = new List<Library.Customer>();
            foreach (var customer in appCustomer)
            {
           //     Console.WriteLine($"{customer.CustomerId}\t\t{customer.FirstName}\t{customer.LastName}\t{customer.Email}");
                customers.Add(customer);
            };
           return appCustomer;
        }

        public List<DataModel.Order> GetCustomerOrders(int customerId)
        {
            using var context = new project0Context(_dbContext);
           var dbOrders= context.Orders
           .Include( o => o.Customer)
           .Include(o => o.Location)
           .Include(o => o.Product)
           .Where( o => o.CustomerId == customerId);

           var orders = new List<DataModel.Order>();
           foreach ( var order in dbOrders)
           {
           //     Console.WriteLine ($"Order Number\t Product Name \t\tQuantity\tLocation ");
            //  Console.WriteLine($"{order.OrderId}\t\t{order.Product.Name}\t{order.OrderQuantity}\t{order.Location.Name}");
              orders.Add(order);
           }
           return orders;
        }

         public Order GetOrderById(int orderId){
            using var context = new project0Context(_dbContext);
            var dbOrders = context.Orders
            .Where(o => o.OrderId == orderId)
            .Include(o => o.Customer)
            .Include(o => o.Location)
            .Include(o => o.Product)
            .First();
         //  Console.WriteLine ($"Order Number\t Product Name \t\tQuantity\tLocation ");
         //  Console.WriteLine($"{dbOrders.OrderId}\t\t{dbOrders.Product.Name}\t{dbOrders.OrderQuantity}\t{dbOrders.Location.Name}");
           return dbOrders;
        }
       public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
       public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
       public Customer GetCustomerByID(int CustomerId)
        {
            throw new NotImplementedException();
        }
       public Product GetProductById(int ProductId)
        {
            throw new NotImplementedException();
        }
        public void AddLocation(Location location)
        {
            throw new NotImplementedException();
        }

       public  void AddCustomer(Library.Customer customer)
        {
        using var context = new project0Context(_dbContext);
           
            var dbCustomer = new StoreApp.DataModel.Customer(){

              FirstName = customer.FirstName,
               LastName = customer.LastName,
                  Email = customer.Email
            };
            
            context.Add(dbCustomer);
            context.SaveChanges();

        }
   public Library.Customer GetCustomerByName(string firstName, string lastName){
            using var context = new project0Context(_dbContext);
            var dbCustomers = context.Customers.First(c => c.FirstName == firstName && c.LastName == lastName);
            
            var customer = new StoreApp.Library.Customer(dbCustomers.CustomerId,dbCustomers.FirstName, dbCustomers.LastName, dbCustomers.Email);
            
           // Console.WriteLine($"{customer.CustomerId}\t{customer.FirstName}\t{customer.LastName}\t{customer.Email}");
            return customer;
        }
       public  void DeleteCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public void AddProdcut(Product product)
        {
            throw new NotImplementedException();
        }
        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
        public void DeleteProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

       public  void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }
        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
        public void DeleteOrder(int OrderId)
        {
            throw new NotImplementedException();
        }


        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}


