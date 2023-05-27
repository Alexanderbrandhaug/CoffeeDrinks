using System.Net;
using dark_roasted_coffee_api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace CoffeAPITests;

public class CoffeeDrinkITTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CoffeeDrinkITTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAllCoffees_ReturnsOkResponse_WhenListIsNotNullOrEmpty()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/coffee-drinks"); // adjust the path accordingly
        
        response.EnsureSuccessStatusCode(); // status code is 200-299

        var coffees = JsonConvert.DeserializeObject<List<CoffeeDrink>>(
            await response.Content.ReadAsStringAsync());

        Assert.NotEmpty(coffees);
    }
    
    [Fact]
    public async Task GetAllCoffeesSortedByIds_ReturnsOkResponse()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/coffee-drinks");
        response.EnsureSuccessStatusCode();

        var coffees = JsonConvert.DeserializeObject<List<CoffeeDrink>>(
            await response.Content.ReadAsStringAsync());
        for (int i = 0; i < coffees.Count - 1; i++)
        {
            Assert.True(coffees[i].displayOrder <= coffees[i + 1].displayOrder);
        }
    }
    
    
    [Fact]
    public async Task GetCoffeeById_ReturnsOkResponse()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/coffee-drinks/405");
        response.EnsureSuccessStatusCode(); // status code is 200-299

        var coffee = JsonConvert.DeserializeObject<CoffeeDrink>(
            await response.Content.ReadAsStringAsync());

        Assert.NotNull(coffee);
    }
    
    
    [Fact]
    public async Task GetCoffeeById_ReturnsNotFoundResponse()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/coffee-drinks/100");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetCoffeeById_ReturnsInternalServerErrorResponse()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/coffee-drinks/0");
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }
}
