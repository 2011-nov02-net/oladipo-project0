using System;
using System.Collections.Generic;
using Xunit;
using StoreApp.Library;

namespace StoreApp.Tests
{
    public class StoreLibTest
    {
        [Fact]
        public void addInvetory()
        {
          string name = "coffee";
          int quantity = 20;
          double price = 2.99;
          var product = new Product(name, price, quantity);
          


        }
    }
}
