using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Library
{
    public class Order
    {

        private string OrderId { get;}
        //store location 
        //public Location  LocationName{ get;}
        //time ordered
        private DateTime Date {get;}
        public int CustomerId {get; set;}
      
        //list of itemrs 
       // public List<OrderItem> OrderItems;

       private static int orderIdSeed = 1;

        //constructors

        public Order(){
             this.OrderId = orderIdSeed.ToString();
            orderIdSeed++; 
        }
        public Order(int orderId){
            this.OrderId = orderId.ToString();
    
        }
      
        public Order GetOrder(int orderId){
            Order order = new Order(orderId);
            return order;
        }
      public List<Order> Orders => new List<Order>();
     }

    //  public Customer customers {get; set;}
}