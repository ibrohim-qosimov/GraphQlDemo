using GraphQlDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GraphQlDemo.Persistance
{
    public class DemoGhCbContext : DbContext
    {
        public DemoGhCbContext(DbContextOptions<DemoGhCbContext> ops)
            : base(ops)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
