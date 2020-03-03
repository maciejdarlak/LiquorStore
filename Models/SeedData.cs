using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LiquorStore.Data;

namespace LiquorStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProductContext>>()))
            {
                if (context.Product.Any())
                {
                    return;
                }

                context.Product.AddRange
                    (
                        new Product
                        {
                            Name = "The Macallan 18 Years Old Single Malt Scotch Whisky",
                            Category = "Spirits",
                            SubCategory = "Scotch",
                            Volume = 700,
                            ProductionYear = 1991,
                            Price = 2099,
                        },

                        new Product
                        {
                            Name = "Cask Matured Highland Single Malt Scotch",
                            Category = "Spirits",
                            SubCategory = "Scotch",
                            Volume = 750,
                            ProductionYear = 2008,
                            Price = 108,
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
