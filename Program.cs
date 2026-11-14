using Microsoft.EntityFrameworkCore;
using BlazingPizza.Data;
using BlazingPizza.Services;
using BlazingPizza;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddDbContext<PizzaStoreContext>(options =>
    options.UseSqlite("Data Source=pizza.db"));
// Registrar el servicio de pizzas
builder.Services.AddSingleton<PizzaService>();
builder.Services.AddScoped<PizzaSalesState>();
builder.Services.AddScoped<OrderState>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapGet("/specials", async (PizzaStoreContext db) =>
    await db.Specials.ToListAsync());
app.MapControllers();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();