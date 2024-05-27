using System.ComponentModel.DataAnnotations;

namespace Uvaan_CLDV_part2.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public bool Availability { get; set; }
    }
}
