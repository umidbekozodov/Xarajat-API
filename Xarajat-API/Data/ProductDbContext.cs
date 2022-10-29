using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Xarajat_API.Entities;

namespace Xarajat_API.Data;

public class ProductDbContext : DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=product.db");
    }
}