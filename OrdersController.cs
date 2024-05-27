using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uvaan_CLDV_part2.Data;
using Uvaan_CLDV_part2.Models;
using Uvaan_CLDV_part2.Extensions; // Add this line

namespace Uvaan_CLDV_part2.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MyVCAppDbContext _context;

        public OrdersController(MyVCAppDbContext context)
        {
            _context = context;
        }

        // GET: Orders/Index
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // GET: Orders/Cart
        public IActionResult Cart()
        {
            var cart = GetCart();
            return View(cart);
        }

        // POST: Orders/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == productId);

            if (cartItem == null)
            {
                cart.Add(new CartItem { ProductId = productId, Product = product, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            SaveCart(cart);

            return RedirectToAction("Cart");
        }

        private List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            foreach (var item in cart)
            {
                item.Product = _context.Products.Find(item.ProductId);
            }
            return cart;
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.Set("Cart", cart);
        }
    }
}
