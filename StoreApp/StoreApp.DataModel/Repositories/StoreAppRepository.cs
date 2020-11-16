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

          //  var Locations = _dbContext.Locations.ToList();
            throw new NotImplementedException();
        }
        public List<Customer> GetCustomers()
        {
            using var context = new project0Context(_dbContext);

            var dbCustomers = context.Customers.ToList();

            var appCustomer = dbCustomers.Select( c => new Customer( c.CustomerId, c.FirstName, c.LastName, c.Email )).ToList();

            return appCustomer;
        }
       public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
       public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

       public Location GetLocationById(int LocationId)
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
        public Order GetOrderById(int OrderId)
        {
            throw new NotImplementedException();
        }

        public void AddLocation(Location location)
        {
            throw new NotImplementedException();
        }
       public void UpdateLocation(Location location)
        {
            throw new NotImplementedException();
        }
        public void DeleteLocation(int LocationId)
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
           context.SaveChanges();
        }
       public  void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
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


