using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.Library
{
    class Order
    {

        private string OrderId { get;}
        //store location 
        public Store  LocationName{ get;}
        
        //time ordered
        private DateTime Date {get;}
        //can contain a list of products

        public Customer Customer {get;}
      
        //list of products 
        private Dictionary<Product, int> Products;

       private static int orderId = 1;

        //constructor
        public Order ( Store name, Customer  cName, DateTime date){
           this.OrderId = orderId.ToString();
             orderId++; 
            this.LocationName = name;
            this.Customer = cName;
            this.Date = date;
            Products = new Dictionary<Product, int>(); 
        }


     }
}