using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    public DbSet<Order> Order { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Pizza> APizzaModel { get; set; }
    public DbSet<User> Users { get; set; }

    public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Order>().HasKey(o => o.EntityId);
      builder.Entity<Store>().HasKey(s => s.EntityId);
      builder.Entity<Pizza>().HasKey(u => u.EntityId);
      builder.Entity<User>().HasKey(p => p.EntityId);

      builder.Entity<Store>().HasData(
        new Store() { EntityId = 2, Name = "Dominoes" },
        new Store() { EntityId = 3, Name = "Pizza Hut" }
      );
    }
  }
}