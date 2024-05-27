using System.ComponentModel.DataAnnotations;

namespace Uvaan_CLDV_part2.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal Price => Product?.Price * Quantity ?? 0;
    }
}
