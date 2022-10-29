using Microsoft.EntityFrameworkCore;
using Xarajat_API.Entities;

namespace Xarajat_API.Data;

public class XarajatDbContext : DbContext
{
    public XarajatDbContext(DbContextOptions options) : base(options) { }
    public DbSet<User>? Users { get; set; }
    public DbSet<Room>? Rooms { get; set; }
    public DbSet<Outlay>? Outlays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<Outlay>().Property(o => o.Description).HasMaxLength(38).IsRequired();
        modelBuilder.Entity<Outlay>().Property(o => o.RoomId).HasColumnName("outlayroomidisdbcontext");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(XarajatDbContext).Assembly);
        // modelBuilder.ApplyConfiguration(new OutlaysConfiguration());
    }
 
}