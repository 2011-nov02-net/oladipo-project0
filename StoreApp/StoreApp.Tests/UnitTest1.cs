using System;
using Xunit;
using StoreApp.Library;

namespace StoreApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void addInventory()
        {
            string name = "coffee";
            int quantity = 20;
            var atlanta = new Store("Atlanta");

            //add inventory
            atlanta.addInventory(name, quantity);

            bool condition = atlanta.Inventory["coffee"] == 20;

            Assert.True(condition);

        }

       // [Fact]

        // public void getInventory()
        // {
        //     string name = "coffee";
        //     int quantity = 20;
        //     var atlanta = new Store("Atlanta");
        //     atlanta.addInventory(name, quantity);

        //     string result = atlanta.getInventory();
        //     bool condition = result.Equals("1\tcoffee\t20");
           
        //    Assert.True(condition);

        // }

           [Fact]
        public void fullNameTest()
        {
            //set up data
            Customer customer = new Customer();
            customer.FirstName = "Omah";
            customer.LastName = "Lay";
            string expected = "Omah Lay";

            //test action
            string actual = customer.FullName;

            
            Assert.True(expected.Equals(actual));

        }


    }
}
