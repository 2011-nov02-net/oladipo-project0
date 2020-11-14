using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataModel
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime Date { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
