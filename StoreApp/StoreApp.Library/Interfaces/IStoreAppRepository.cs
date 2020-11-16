using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library.Interfaces;
using StoreApp.Library;


namespace StoreApp.Library.Interfaces
{
    ///<summary>
    ///A repository managing data access for store locations, their customers, their locations and their orders
    ///</summary>

    ///<remarks>
    ///
    ///</remarks>

    public interface IStoreAppInterface
    {
        ///<summary>
        ///Get all locations on deffered execution
        ///</summary>
        ///<returns>The collection of restaurants</returns>
        IEnumerable<Location> GetLocations();
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Product> GetProducts();
        IEnumerable<Order> GetOrders();

        Location GetLocationById(int LocationId);
        Customer GetCustomerByID(int CustomerId);
        Product GetProductById(int ProductId);
        Order GetOrderById(int OrderId);

        void AddLocation(Location location);
        void UpdateLocation(int LocationId, int ProductId, int orderQuantity);
       

        void AddCustomer(Customer customer);
       // void UpdateCustomer(Customer customer);
       

        void AddProdcut(Product product);
       // void UpdateProduct(Product product);
       

        void AddOrder( Order order);
        void UpdateOrder( Order order);

       

       void Save();


    }
}