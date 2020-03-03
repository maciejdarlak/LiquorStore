using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquorStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public double Volume { get; set; }
        public int ProductionYear { get; set; }
        public decimal Price { get; set; }
    }
}
