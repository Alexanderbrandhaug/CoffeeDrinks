using dark_roasted_coffee_api.Controllers;
using dark_roasted_coffee_api.Models;
using dark_roasted_coffee_api.Repository;
using dark_roasted_coffee_api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CoffeAPITests;

public class CoffeeDrinksUnitTests
{
    private readonly ICoffeeRepository _coffeeRepository;
    private readonly CoffeeController _coffeeController;
    

    public CoffeeDrinksUnitTests()
    {
        _coffeeRepository = new CoffeeService();
        _coffeeController = new CoffeeController(_coffeeRepository);
    }

    [Fact]
    public async Task GetAllCoffees_ReturnsAllCoffeeDrinks()
    {
        var result = await _coffeeController.GetAllCoffees();
        var okResult = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
        Assert.IsAssignableFrom<List<CoffeeDrink>>(okResult.Value);
        var coffeeDrinks = okResult.Value;
        Assert.NotNull(coffeeDrinks);
    }
    
    [Fact]
    public async void GetAllCoffees_ReturnsEmptyCoffeeDrinks()
    {
        var coffeeRepositoryMock = new Mock<ICoffeeRepository>();
        coffeeRepositoryMock
            .Setup(repo => repo.GetAllCoffees())
            .Returns(new List<CoffeeDrink>());


        var coffeeController = new CoffeeController(coffeeRepositoryMock.Object);
        
        var result = await coffeeController.GetAllCoffees();
        
        var objectResult = Assert.IsType<ObjectResult>(result.Result);
        Assert.Equal(500, objectResult.StatusCode);
        
        // Verify that the GetAllCoffees method was called
        coffeeRepositoryMock.Verify(repo => repo.GetAllCoffees(), Times.Once);
    }
}

