using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool Paid { get; set; }
        public bool Delivered { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateDelivery { get; set; } = default;
        public string? Note { get; set; } = default;

        public Customer Customer { get; set; } = null!;
        public List<OrderProduct> OrderProducts { get; set; } = [];
    }
}