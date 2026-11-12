namespace BlazingPizza.Data;

public class PizzaService
{
    public async Task<Pizza[]> GetPizzasAsync()
    {
        // Simulamos una llamada a base de datos con datos de ejemplo
        return await Task.FromResult(new Pizza[]
        {
            new Pizza { PizzaId = 1, Name = "Classic Margherita", Description = "Tomato sauce, mozzarella, and basil", Price = 9.99M, Vegetarian = true, Vegan = false },
            new Pizza { PizzaId = 2, Name = "Meat Lovers", Description = "Pancetta, meatballs, sausage, and pepperoni", Price = 12.99M, Vegetarian = false, Vegan = false },
            new Pizza { PizzaId = 3, Name = "Veggie Supreme", Description = "Tomatoes, peppers, onions, and olives", Price = 11.49M, Vegetarian = true, Vegan = true }
        });
    }
}