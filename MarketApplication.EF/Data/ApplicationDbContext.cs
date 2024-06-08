using MarketApplication.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketApplication.EF.Data;
public partial class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions options) :base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(ConfigureProduct);

        modelBuilder.Entity<Category>(ConfigureCategory);
    }

}

