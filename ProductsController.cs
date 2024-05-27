using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Uvaan_CLDV_part2.Data;

namespace Uvaan_CLDV_part2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyVCAppDbContext _context;

        public ProductsController(MyVCAppDbContext context)
        {
            _context = context;
        }

        // GET: Work
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();

            // Debugging step to check if products are being fetched
            if (products == null || !products.Any())
            {
                // Log a message to console or debug output
                System.Diagnostics.Debug.WriteLine("No products found in the database.");
            }
            else
            {
                // Log the count of products fetched
                System.Diagnostics.Debug.WriteLine($"Fetched {products.Count} products from the database.");
            }

            return View(products);
        }
    }
}
