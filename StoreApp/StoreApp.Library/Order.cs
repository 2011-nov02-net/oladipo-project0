using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Library
{
    public class Order
    {

        private static int _orderIdSeed = 1;

        private string OrderId { get; set; }
        //store location 
        public string LocationName { get; }
        //time ordered
        private DateTime Date { get; }
        private int CustomerId { get; }

        //list of items 
        private List<Customer> Customers;
        private int _productQuantity;

        public int ProductQuantity
        {
            get { return _productQuantity; }
            set
            {
                if (value > 50)
                {
                    throw new ArgumentOutOfRangeException("value", "Price can not be a negative");
                }
                _productQuantity = value;
            }
        }

        public void newOrder(string productId, int quantity, int customerId)
        {
            OrderId = _orderIdSeed.ToString();
            _orderIdSeed++;
            Customers = new List<Customer>();
            Customer customer = new Customer(customerId);
            Customers.Add(customer);

        }

        public Order()
        {
            this.OrderId = _orderIdSeed.ToString();
            _orderIdSeed++;
        }
        public Order(int orderId)
        {
            this.OrderId = orderId.ToString();

        }
    }


}

