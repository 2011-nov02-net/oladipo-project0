using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Library
{
    public class Order
    {

        public int OrderId { get; set; }
        //store location 
        public int LocationId { get; set; }
        //time ordered
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int OrderQuantity { get; set; }


        public Order ( ){
            
        }

        // public void newOrder(string productId, int quantity, int customerId)
        // {
        //     OrderId = _orderIdSeed.ToString();
        //     _orderIdSeed++;
        //     Customers = new List<Customer>();
        //     Customer customer = new Customer(customerId);
        //     Customers.Add(customer);

        // }

        // public Order()
        // {
        //     this.OrderId = _orderIdSeed.ToString();
        //     _orderIdSeed++;
        // }
        // public Order(int orderId)
        // {
        //     this.OrderId = orderId.ToString();

        // }
    }


}

