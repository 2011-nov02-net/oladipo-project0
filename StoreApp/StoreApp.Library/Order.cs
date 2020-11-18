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


        public Order()
        {

        }

    }


}

