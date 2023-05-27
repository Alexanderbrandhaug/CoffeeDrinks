using dark_roasted_coffee_api.Models;
using dark_roasted_coffee_api.Repository;
using Newtonsoft.Json;


namespace dark_roasted_coffee_api.Services;

public class CoffeeService : ICoffeeRepository
{
    private readonly string pathToJson = "Data/CoffeeData.json";
    private List<CoffeeDrink> _coffeeList;
    

    // if we want to improve performance. We can use a dict instead of a list <id, coffeedrink> 
    // this would enhance the performance to constant time
    public List<CoffeeDrink> GetAllCoffees()
    {
        if (File.Exists(pathToJson) && _coffeeList == null)
        {
            string content = File.ReadAllText(pathToJson);
            _coffeeList = JsonConvert.DeserializeObject<List<CoffeeDrink>>(content);
            
        }
        return _coffeeList?.OrderBy(coffee => coffee.displayOrder).ToList() ?? new List<CoffeeDrink>();
    }

    public CoffeeDrink GetCoffeeById(int id)
    {
        _coffeeList = GetAllCoffees();
        if (_coffeeList == null || _coffeeList.Count == 0)
        {
            return null;
        }
        return _coffeeList.FirstOrDefault(coffee => coffee.id == id);
    }
}