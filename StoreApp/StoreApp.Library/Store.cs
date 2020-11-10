using System;
using System.Collections.Generic;
using System.Linq;


namespace StoreApp.Library
{
    public class Store
    {
        //location name
        private string _locationName;
        //store id. This initates to 0
        private int _id = 0;
    


        //Id increments by 1 each time a constructor is called.
        public int ID { get; set; } = ++_id; 

        public string Name{
            get => _locationName= Name;
            set { 
                if ( value.Length == 0){
                   throw new ArgumentException("Name field must not be empty.");
              }
              _firstName = value;
              }

        }

        //list of inventory in each store
        public List<Product> Products { get; set} = new List<Product>();

        
    }
}