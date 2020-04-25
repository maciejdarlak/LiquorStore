using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;  //The Nuget package Manager file has been downloaded
using LiquorStore.Models;


namespace LiquorStore.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) //DbContext must have an instance of DbContextOptions
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
