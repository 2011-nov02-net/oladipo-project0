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
            var atlanta = new Location("Atlanta");

            //add inventory
            atlanta.addInventory(name, quantity);

            bool condition = atlanta.Inventory["coffee"] == 20;

            Assert.True(condition);

        }
          [Fact]
        public void getInventory()
        {
            string name = "coffee";
            int quantity = 20;
            var atlanta = new Location("Atlanta");

            //add inventory
            atlanta.addInventory(name, quantity);

            string actual = atlanta.getInventory()[0];

            string expected = "1\tcoffee\t20";

            Assert.True(actual.Equals(expected));

        }


           [Fact]
        public void fullNameTest()
        {
            //set up data
            var customer = new Customer();
            customer.FirstName = "Omah";
            customer.LastName = "Lay";
            string expected = "Omah Lay";

            //test action
            string actual = customer.FullName;

            
            Assert.True(expected.Equals(actual));

        }

         [Fact]
        public void instanceTest()
        {
            //set up data
           var customer1 = new Customer();
            customer1.FirstName = "Omah";
            customer1.LastName = "Lay";
            Customer.InstanceCount += 1;
           var customer2 = new Customer();
           customer1.FirstName = "Burna";
            customer1.LastName = "Boy";
            Customer.InstanceCount += 1;


           

            //test action
            Assert.True(Customer.InstanceCount == 2);

        }
       
          [Fact]
        public void addLocations()
        {
           string name = "kennesaw";
         var kennesaw = new Store(name);

        //     //add inventory
        //     atlanta.addInventory(name, quantity);

        //     bool condition = atlanta.Inventory["coffee"] == 20;

        //     Assert.True(condition);

         }

    }
}
