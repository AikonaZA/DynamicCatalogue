using Microsoft.EntityFrameworkCore;
using Ordering.Data.Models;

namespace Ordering.Data;

public class OrderingDbContext(DbContextOptions<OrderingDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}