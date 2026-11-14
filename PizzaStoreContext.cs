using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

public class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<PizzaSpecial> Specials { get; set; }
    public DbSet<Topping> Toppings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
        modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(pizza => pizza.Toppings);
        modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();

        modelBuilder.Entity<PizzaSpecial>().HasData(
            new PizzaSpecial { Id = 1, Name = "The Baconatorizor", BasePrice = 11.99m, Description = "It has EVERY kind of bacon", ImageUrl = "img/pizzas/bacon.jpg" },
            new PizzaSpecial { Id = 2, Name = "Buffalo chicken", BasePrice = 12.75m, Description = "Spicy chicken, hot sauce, and blue cheese, guaranteed to warm you up", ImageUrl = "img/pizzas/meaty.jpg" },
            new PizzaSpecial { Id = 3, Name = "Veggie Delight", BasePrice = 11.5m, Description = "It's like salad, but on a pizza", ImageUrl = "img/pizzas/salad.jpg" },
            new PizzaSpecial { Id = 4, Name = "Margherita", BasePrice = 9.99m, Description = "Traditional Italian pizza with tomatoes and basil", ImageUrl = "img/pizzas/margherita.jpg" },
            new PizzaSpecial { Id = 5, Name = "Basic Cheese Pizza", BasePrice = 11.99m, Description = "It's cheesy and delicious. Why wouldn't you want one?", ImageUrl = "img/pizzas/cheese.jpg" },
            new PizzaSpecial { Id = 6, Name = "Classic pepperoni", BasePrice = 10.5m, Description = "It's the pizza you grew up with, but Blazing hot!", ImageUrl = "img/pizzas/pepperoni.jpg" });
    }
}
