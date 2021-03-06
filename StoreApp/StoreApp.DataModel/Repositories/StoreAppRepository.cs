using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StoreApp.Library.Interfaces;

namespace StoreApp.DataModel.Repositories
{
    /// <summary>
    /// A repository managing data access for a store objects and their members,
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class StoreAppRepository : IStoreAppRepository
    {
        private readonly DbContextOptions<project0Context> _dbContext;

        /// <summary>
        /// Initializes a new StoreApp Repository given a suitable store data source.
        /// </summary>
        /// <param name="dbContext">The data source</param>
        public StoreAppRepository(DbContextOptions<project0Context> dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Get all locations with deferred execution,
        /// including associated reviews.
        /// </summary>
        /// <returns>The collection of Locations</returns>
        public List<Library.Location> GetLocations()
        {

            using var context = new project0Context(_dbContext);

            var dbLocations = context.Locations.ToList();

            var appLocations = dbLocations.Select(l => new StoreApp.Library.Location(l.LocationId, l.Name, l.Address, l.City, l.State)).ToList();


            return appLocations;
        }
        /// <summary>
        /// Get a Location by ID.
        /// </summary>
        /// <returns>The Location</returns>
        public DataModel.Location GetLocationById(int locationId)
        {
            using var context = new project0Context(_dbContext);

            var dbLocation = context.Locations
            .Include(o => o.Inventories)
            .ThenInclude(o => o.Product)
            .First(o => o.LocationId == locationId);

            return dbLocation;
        }
        /// <summary>
        /// Update an Inventory
        /// </summary>
        /// <returns>The Inventory with changed values</return>
        public DataModel.Inventory UpdateInventory(int locationId, int productId, int quantity)
        {
            using var context = new project0Context(_dbContext);

            var inventory = context.Inventories
            .Include(o => o.LocationId == locationId)
            .Include(o => o.ProductId == productId)
            .First();

            inventory.Quantity -= quantity;
            context.SaveChanges();
            return inventory;
        }

        /// <summary>
        /// Gets all customers from database
        /// </summary>
        /// <returns>The Customers</returns>
        public List<Library.Customer> GetCustomers()
        {
            using var context = new project0Context(_dbContext);

            var dbCustomers = context.Customers.ToList();

            var appCustomer = dbCustomers.Select(c => new StoreApp.Library.Customer(c.CustomerId, c.FirstName, c.LastName, c.Email)).ToList();

            var customers = new List<Library.Customer>();
            foreach (var customer in appCustomer)
            {
                customers.Add(customer);
            };
            return appCustomer;
        }


        /// <summary>
        /// Gets all others for a particular customer
        /// </summary>
        /// <returns>Customer's Orders</param>

        public List<DataModel.Order> GetCustomerOrders(int customerId)
        {
            using var context = new project0Context(_dbContext);
            var dbOrders = context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Location)
            .Include(o => o.Product)
            .Where(o => o.CustomerId == customerId);

            var orders = new List<DataModel.Order>();
            foreach (var order in dbOrders)
            {
                orders.Add(order);
            }
            return orders;
        }

        /// <summary>
        /// Gets Orders for a particular location
        /// </summary>
        /// <returns>Location's Orders</returns>
        public List<DataModel.Order> GetOrdersByLocationId(int locationId)
        {
            using var context = new project0Context(_dbContext);
            var dbOrders = context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Product)
            .Include(o => o.Location)
            .Where(o => o.LocationId == locationId);

            var orders = new List<DataModel.Order>();
            foreach (var order in dbOrders)
            {
                orders.Add(order);
            }

            return orders;

        }
        /// <summary>
        /// Adds a customer
        /// </summary>
        /// <param name="customer">Added customer</param>
        public void AddCustomer(Library.Customer customer)
        {
            using var context = new project0Context(_dbContext);

            var dbCustomer = new StoreApp.DataModel.Customer()
            {

                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };

            context.Add(dbCustomer);
            context.SaveChanges();

        }

        /// <summary>
        /// Adds order to a particular customer
        /// </summary>
        /// <param name="order">Order Added</param>
        public void AddOrderByCustomerId(int customerId, int productId, int locationId, int quantity)
        {
            using var context = new project0Context(_dbContext);
            var dbOrders = new DataModel.Order()
            {
                CustomerId = customerId,
                ProductId = productId,
                LocationId = locationId,
                OrderQuantity = quantity,
            };

            context.Add(dbOrders);
            context.SaveChanges();
        }


        /// <summary>
        /// Gets Inventory of a Location
        /// </summary>
        /// <returns>Location's inventory</returns>
        public List<DataModel.Inventory> GetInventoryByLocationId(int locationId)
        {
            using var context = new project0Context(_dbContext);

            var dbInventory = context.Inventories
            .Include(i => i.Product)
            .Include(i => i.Location)
            .Where(i => i.LocationId == locationId);

            List<DataModel.Inventory> Inventories = new List<DataModel.Inventory>();
            foreach (var inventory in dbInventory)
            {
                Inventories.Add(inventory);
            }
            return Inventories;
        }

        /// <summary>
        /// Gets Orders By Id
        /// </summary>
        /// <returns> Order</returns>
        public Order GetOrderById(int orderId)
        {
            using var context = new project0Context(_dbContext);
            var dbOrders = context.Orders
            .Where(o => o.OrderId == orderId)
            .Include(o => o.Customer)
            .Include(o => o.Location)
            .Include(o => o.Product)
            .First();
            return dbOrders;
        }

        /// <summary>
        /// Gets Customer By Name
        /// </summary>
        /// <returns>Customer</returns>
        public Library.Customer GetCustomerByName(string firstName, string lastName)
        {
            using var context = new project0Context(_dbContext);
            var dbCustomers = context.Customers.First(c => c.FirstName == firstName && c.LastName == lastName);

            var customer = new StoreApp.Library.Customer(dbCustomers.CustomerId, dbCustomers.FirstName, dbCustomers.LastName, dbCustomers.Email);

            return customer;
        }


    }
}


