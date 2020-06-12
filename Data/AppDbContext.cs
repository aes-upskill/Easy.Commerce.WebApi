using Easy.Commerce.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Easy.Commerce.WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
