using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Black.Steel.Langley.Domain.Orders;

    public class Class1 : DbContext
    {
        public Class1 (DbContextOptions<Class1> options)
            : base(options)
        {
        }

        public DbSet<Black.Steel.Langley.Domain.Orders.Order> Order { get; set; } = default!;
    }
