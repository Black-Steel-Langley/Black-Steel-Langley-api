using System.Collections.Generic;
using System.Linq;

namespace Black.Steel.Langley.Domain.Orders
{
    public class Order {
        public int ID { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice => Items.Sum(i => i.Price);

    }

    public class OrderItem
    {
        public int ID { get; set; }
        public int Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price => Price * Quantity;
    }
}