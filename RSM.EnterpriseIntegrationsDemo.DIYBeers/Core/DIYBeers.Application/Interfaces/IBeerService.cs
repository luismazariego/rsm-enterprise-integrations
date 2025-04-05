using DIYBeers.Application.DTOs;

namespace DIYBeers.Application.Interfaces;

public interface IBeerService
{
    Task<int> AddBeers(List<BeerDto> beers);
    Task<int> AddBeer(BeerDto beer);
    
    Task<IEnumerable<BeerDto>> GetAllBeers();
    Task<BeerDto?> GetBeer(int id);
    Task<IEnumerable<BeerDto>> GetBeerByAbV(float abv);
    Task<IngredientsDto?> GetIngredientsByBeerId(int beerId);
    Task<IngredientsDto?> GetIngredientsByBeerName(string beerName);
}
