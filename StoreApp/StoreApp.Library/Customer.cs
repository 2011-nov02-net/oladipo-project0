using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.Library
{

    public class Customer
    {

        //name
        private string _firstName;
        private string _lastName;
        //customer id
        public string CustomerID { get; }
        //default store 
        public int DefaultStore {get; set;}


        // set names to not allow empty string
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(message: "invalid FIrstname", paramName: nameof(value));
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(message: "invalid Lastname", paramName: nameof(value));
                }
                _lastName = value;
            }
        }

        //constructor

        private static int customerIdSeed = 1;
        public Customer(string first, string last)
        {
            this.CustomerID = customerIdSeed.ToString();
            customerIdSeed++;
            this.FirstName = first;
            this.LastName = last;
        }

        //add defualt store 
         public void addDefaultStore(int StoreId){
           DefaultStore = StoreId;
         }
        //list of orders 
        private List<Order> Orders { get; set; } = new List<Order>();

    }
}