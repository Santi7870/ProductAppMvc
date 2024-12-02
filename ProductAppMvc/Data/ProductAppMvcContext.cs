using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductAppMvc.Models;

namespace ProductAppMvc.Data
{
    public class ProductAppMvcContext : DbContext
    {
        public ProductAppMvcContext (DbContextOptions<ProductAppMvcContext> options)
            : base(options)
        {
        }

        public DbSet<ProductAppMvc.Models.Product> Product { get; set; } = default!;
        public DbSet<Product> Products { get; set; }

    }
}
