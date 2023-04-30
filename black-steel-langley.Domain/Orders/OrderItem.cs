using Black.Steel.Langley.Domain.Catalog;    

namespace Black.Steel.Langley.Domain.Orders {
   public class OrderItem {
        public int ID { get; set; }
        public int Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price => Price * Quantity;
    }
}