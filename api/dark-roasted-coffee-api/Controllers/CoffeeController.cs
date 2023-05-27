using dark_roasted_coffee_api.Models;
using dark_roasted_coffee_api.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace dark_roasted_coffee_api.Controllers;

[ApiController]
[Route("/coffee-drinks")]
public class CoffeeController : ControllerBase
{
    private readonly Error _errormsg;
    private readonly ICoffeeRepository _coffeeRepository;
    
    
    public CoffeeController(ICoffeeRepository coffeeRepository)
    {
        _errormsg = new Error(500, "Something went wrong");
        _coffeeRepository = coffeeRepository;

    }
    
    
    [HttpGet]
    [SwaggerResponse(200, "List of Coffee drinks")]
    [SwaggerOperation(Summary = "List Coffee Drinks", Description = "Returns a list of Coffe Drink objects.")]
    [Produces("application/json")]
    public async Task<ActionResult<List<CoffeeDrink>>> GetAllCoffees()
    {
        var list =  _coffeeRepository.GetAllCoffees();
        if (list == null || list.Count == 0) return StatusCode(_errormsg.code, _errormsg.message);
        
        return Ok(list);
    }
    
    [HttpGet]
    [Route("/coffee-drinks/{id}")]
    [SwaggerResponse(200, "Details about a specific Coffee Drink")]
    [SwaggerOperation(Summary = "Retrieve a Coffee drink", Description = "Retrieves a single CoffeeDrink object. It has details about a particular coffee drink.")]
    [Produces("application/json")]
    public async Task<ActionResult<CoffeeDrink>> GetCoffeeById(int id)
    {
        if (id == null || id == 0) return StatusCode(_errormsg.code, _errormsg.message);
        
        var coffee = _coffeeRepository.GetCoffeeById(id);
        if (coffee == null) return NotFound("No Coffee found with id: " + id);
        return Ok(coffee);
    }
}