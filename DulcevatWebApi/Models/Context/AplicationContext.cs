using Microsoft.EntityFrameworkCore;

namespace DulcevatWebApi.Models.Context
{
    public class AplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }
    }
}
