using dark_roasted_coffee_api.Models;

namespace dark_roasted_coffee_api.Repository;

public interface ICoffeeRepository
{
    List<CoffeeDrink> GetAllCoffees();
    CoffeeDrink GetCoffeeById(int id);
}