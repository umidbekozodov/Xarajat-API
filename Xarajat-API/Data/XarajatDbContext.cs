using Microsoft.EntityFrameworkCore;
using Xarajat_API.Entities;

namespace Xarajat_API.Data;

public class XarajatDbContext : DbContext
{
    public XarajatDbContext(DbContextOptions options) : base(options) { }
    public DbSet<User>? Users { get; set; }
    public DbSet<Room>? Rooms { get; set; }
    public DbSet<Outlay>? Outlays { get; set; }
}