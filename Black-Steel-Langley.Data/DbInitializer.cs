using Black.Steel.Langley.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Black.Steel.Langley.Data {
    public static class DbInitializer {
        public static void Initialize(ModelBuilder builder) {
            builder.Entity<Item>().HasData(
                new Item("Shirt", "Ohio State shit", "Nike", 29.99M) {
                    Id = 1
                },
                new Item("Shorts", "Ohio State shorts", "Nike", 44.99m) {
                    Id = 2
                }
            );
        }
    }
}