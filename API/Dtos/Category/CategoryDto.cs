using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Category
{
   public sealed record CategoryDto (
        string Name
        // public List<Product> Products { get; set; } = new List<Product>();
   );
}