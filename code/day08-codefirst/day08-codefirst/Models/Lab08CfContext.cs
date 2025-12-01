using Microsoft.EntityFrameworkCore;

namespace day08_codefirst.Models
{
    public class Lab08CfContext : DbContext
    {
        public Lab08CfContext(DbContextOptions<Lab08CfContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
