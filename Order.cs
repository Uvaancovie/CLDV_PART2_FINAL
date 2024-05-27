using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Uvaan_CLDV_part2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
