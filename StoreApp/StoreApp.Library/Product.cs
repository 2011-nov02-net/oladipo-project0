using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.Library
{

   /// <summary>
   /// A product class, having a name, a product ID that increaments when creating a new instance of a product,
   /// the quantity of products and its availability. 
   ///</summary>

       public class Product
    {
       
       //product id
        private int _id = 0;
       //increment the id with each new product added
        public int ID{ get; set;} = ++_id;


       //name
       private string _name;

       public string Name {
           get { return _name;}
           //Name can not be an empty string. If name is epmty, throw an exception
           set {
                if (value.Length == 0){
                    throw new ArgumentException("Name must not be empty.");
                }
                _name = value;
           }

       }
       //price
       private double _price;

       public double Price {
           get {return _price;}
           //the price of the product cannot be 0 or a negative number 
            set {
                if ( value <= 0 ){
                    throw new ArgumentOutOfRangeException("value", "Price can not be a negative");
                }
               _price = value;
           }
       }

       //quantity in stock
       private int _quantity; 
       public int Quantity {
              get{return _quantity; } 
              //the quantity of the product cannot be negative
              private set 
               {
                     if ( value < 0){
                         throw new ArgumentOutOfRangeException("value", "Quantitiy can not be a negative");

                    }
                    _quantity = value;
                }
           }

       //constructor 

       public Product(string name, double price, int quantity){
                Quantity = quantity;
                Price = price;
                Name = name;
       }

    //    public void AddInventory ( int count){
    //        Quantity += count;
    //    }
    }
}
