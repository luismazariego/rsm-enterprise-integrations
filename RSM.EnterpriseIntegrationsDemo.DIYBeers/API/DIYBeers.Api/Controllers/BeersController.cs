using DIYBeers.Application.DTOs;
using DIYBeers.Application.Interfaces;
using DIYBeers.Application.Mapping;
using DIYBeers.Domain.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace DIYBeers.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeersController(IBeerService service, IDiyBeerApi beerApiClient) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetBeers()
    {
        return Ok(await service.GetAllBeers());
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> ImportBeers(ImportBeersParameters parameters)
    {
        var beers = await beerApiClient
            .GetBeerDetails(parameters.Page, parameters.PerPage, parameters.FoodSearch)
            .ConfigureAwait(false);
        
        if (beers is null or { Count: 0 })
        {
            return NoContent();
        }

        var result = beers.Count == 1 
            ? await service.AddBeer(beers.First().ToBeerDto()) 
            : await service.AddBeers(beers.Select(beer => beer.ToBeerDto()).ToList());
        
        return Ok($"{result} Beers added");
    }

    [HttpGet]
    [Route("abv/{abv:float}")]
    public async Task<IActionResult> GetBeersByAbV(float abv)
    {
        return Ok(await service.GetBeerByAbV(abv));
    }

    public record ImportBeersParameters
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 10;
        public string FoodSearch { get; set; } = "Chocolate";
    }
}
