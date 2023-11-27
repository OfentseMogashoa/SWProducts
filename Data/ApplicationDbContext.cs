using Microsoft.EntityFrameworkCore;
using SWProducts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SWProducts.Data
{
    
    public class ApplicationDbContext : IdentityDbContext<SuperUser>
    {
        public virtual DbSet<Product> Products { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}