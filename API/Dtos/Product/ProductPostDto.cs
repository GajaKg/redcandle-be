using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Product
{
    public class ProductPostDto
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int StockCapacity { get; set; }
        public int Reserved { get; set; }
    }
}