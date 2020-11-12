using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.Library
{

    public class OrderItem 
    {

    //order item id
     private string OrderItemId { get; }

    private static int orderItemSeed = 1;

     //Quantity of order
     public int OrderQuantity {get; set;}
     //Product Id to add products
     public int ProductId {get; set;}
     
     public double price {get; set;}

    public OrderItem(){
        this.OrderItemId = orderItemSeed.ToString();
        orderItemSeed++;
    }
   public OrderItem(int orderItemId){
       this.OrderItemId = orderItemId.ToString();
   }
    
// get all orderItems
    // public OrderItem getOrderItem(int ){

    // }

    }
}