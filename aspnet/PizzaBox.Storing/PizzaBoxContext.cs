using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    public DbSet<Order> Order { get; set; }
    public DbSet<Store> Stores { get; set; }

    public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Order>().HasKey(o => o.EntityId);
      builder.Entity<Store>().HasKey(s => s.EntityId);

      builder.Entity<Store>().HasData(
        new Store() { EntityId = 2, Name = "Dominoes" },
        new Store() { EntityId = 3, Name = "Pizza Hut" }
      );


      // builder.Entity<Order>().HasOne(o => o.Store).WithMany(s => s.Orders);
      // builder.Entity<Store>().HasMany(s => s.Orders).WithOne(o => o.Store);
      // builder.Entity<Pizza>().HasMany<Topping>(p => p.Ingredients).WithMany(t => t.Pizzas);
    }
  }
}