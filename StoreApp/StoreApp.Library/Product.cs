using System;

namespace StoreApp.Library
{

    /// <summary>
    /// A product class, having a name, a product ID that increaments when creating a new instance of a product,
    /// the quantity of products and its availability. 
    ///</summary>

    public class Product
    {

        //product id
        public string ProductID { get; }
        //name
        private string _name;
        //price
        private double _price;
        //quantity in stock
        private int _quantity;
        public string Name
        {
            get { return _name; }
            //Name can not be an empty string. If name is epmty, throw an exception
            set
            {
             if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(message: "invalid Lastname", paramName: nameof(value));
                }
                _name = value;
            }

        }

        public double Price
        {
            get { return _price; }
            //the price of the product cannot be 0 or a negative number 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Price can not be a negative");
                }
                _price = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Quantitiy can not be a negative");

                }
                _quantity = value;
            }
        }

        //constructor 
        private static int productIdSeed = 1;
        public Product( string name, double price, int quantity)
        {
            this.ProductID = productIdSeed.ToString();
            productIdSeed++;
            this.Quantity = quantity;
            this.Price = price;
            this.Name = name;
        }

        public void addQuantity( int amount){
            Quantity = Quantity + amount;
        }
    }
}
