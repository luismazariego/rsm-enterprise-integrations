using DIYBeers.Domain.Entities;

namespace DIYBeers.Domain.Interfaces;

public interface IRepository
{
    Task<int> AddBeer(Beer beer);
    Task<int> AddIngredient(Ingredients ingredient);
    
    Task<IEnumerable<Beer>> GetAllBeers();
    Task<Beer?> GetBeer(int id);
    Task<IEnumerable<Beer>> GetBeerByAbV(float abv);
    Task<Ingredients?> GetIngredientsByBeerId(int beerId);
    Task<Ingredients?> GetIngredientsByBeerName(string beerName);
}
