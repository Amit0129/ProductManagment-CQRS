using Microsoft.EntityFrameworkCore;

namespace ProductManagment_CQRS.Entity
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
