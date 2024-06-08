using MarketApplication.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketApplication.EF.Data;
public partial class ApplicationDbContext
{

    private void ConfigureProduct(EntityTypeBuilder<Product> obj)
    {
        obj.HasKey(b => b.Id);

        obj.HasIndex(b => b.Name).IsUnique();
        obj.Property(b=>b.Name)
            .IsRequired()
            .HasMaxLength(50);

        obj.Property(b => b.Price)
            .IsRequired();

        obj.Property(b => b.IsActive).HasDefaultValue(true);

        obj.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();

    }

    private void ConfigureCategory(EntityTypeBuilder<Category> obj)
    {
        obj.HasKey(b => b.Id);

        obj.HasIndex(b => b.Name)
            .IsUnique();

        obj.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(50);

        obj.Property(b => b.Description)
            .HasMaxLength(100);

    }

   
}

