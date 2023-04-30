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
}