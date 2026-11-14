using BlazingPizza.Data;
using BlazingPizza.Services;
using BlazingPizza;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
// Registrar el servicio de pizzas
builder.Services.AddSingleton<PizzaService>();
builder.Services.AddScoped<PizzaSalesState>();
builder.Services.AddScoped<OrderState>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapGet("/specials", () => new[]
{
    new PizzaSpecial { Id = 1, Name = "The Baconatorizor", BasePrice = 11.99m, Description = "It has EVERY kind of bacon", ImageUrl = "img/pizzas/bacon.jpg" },
    new PizzaSpecial { Id = 2, Name = "Buffalo chicken", BasePrice = 12.75m, Description = "Spicy chicken, hot sauce, and blue cheese, guaranteed to warm you up", ImageUrl = "img/pizzas/meaty.jpg" },
    new PizzaSpecial { Id = 3, Name = "Veggie Delight", BasePrice = 11.5m, Description = "It's like salad, but on a pizza", ImageUrl = "img/pizzas/salad.jpg" },
    new PizzaSpecial { Id = 4, Name = "Margherita", BasePrice = 9.99m, Description = "Traditional Italian pizza with tomatoes and basil", ImageUrl = "img/pizzas/margherita.jpg" },
    new PizzaSpecial { Id = 5, Name = "Basic Cheese Pizza", BasePrice = 11.99m, Description = "It's cheesy and delicious. Why wouldn't you want one?", ImageUrl = "img/pizzas/cheese.jpg" },
    new PizzaSpecial { Id = 6, Name = "Classic pepperoni", BasePrice = 10.5m, Description = "It's the pizza you grew up with, but Blazing hot!", ImageUrl = "img/pizzas/pepperoni.jpg" }
});

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();