using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.Library
{
    class Order
    {
        //store location 
        public Store LocationName{ get;}
        
        //time ordered
        private DateTime Date {get;}
        //can contain a list of products

        public Customer Customer {get;}
      
        //list of products 
        private Dictionary<Product, int> Products;



        //constructor
        public Order ( Store name, Customer  cName, DateTime date, Dictionary<Product, int> products){
            LocationName = name;
            Customer = cName;
            Date = date;
            Products = new Dictionary<Product, int>(); 
        }


     }
}