using Microsoft.EntityFrameworkCore;
using Uvaan_CLDV_part2.Models;

namespace Uvaan_CLDV_part2.Data
{
    public class MyVCAppDbContext : DbContext
    {
        public MyVCAppDbContext(DbContextOptions<MyVCAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
