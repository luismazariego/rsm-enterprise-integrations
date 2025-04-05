using DIYBeers.Application.CustomExceptions;
using DIYBeers.Application.DTOs;
using DIYBeers.Application.Interfaces;
using DIYBeers.Application.Mapping;
using DIYBeers.Domain.Entities;
using DIYBeers.Domain.Interfaces;

namespace DIYBeers.Application.Services;

public class BeerService(IRepository repository) : IBeerService
{
    public async Task<int> AddBeers(List<BeerDto> beers)
    {
        if (beers is null or { Count: 0 })
        {
            return 0;
        }
        var success = 0;
        foreach (var beer in beers)
        {
            var existingBeer = await repository.GetBeer(beer.Id).ConfigureAwait(false);
            if (existingBeer is not null)
            {
                continue;
            }
            if (string.IsNullOrWhiteSpace(beer.Name) 
                || string.IsNullOrWhiteSpace(beer.Description)
                || string.IsNullOrWhiteSpace(beer.Tagline)
                || beer.FoodPairing.Count == 0
                || string.IsNullOrWhiteSpace(beer.FirstBrewed))
            {
                continue;
            }
            var beerDb = beer.ToBeer();
            var ingredientsDb = BeerMapping.ToIngredients(beer.Ingredients);
            beerDb.IngredientsId = ingredientsDb.Id;
            ingredientsDb.BeerId = beerDb.Id;
            await repository.AddBeer(beerDb).ConfigureAwait(false);
            await repository.AddIngredient(ingredientsDb).ConfigureAwait(false);
            
            success++;
        }
        
        return success;
    }

    public async Task<int> AddBeer(BeerDto beer)
    {
        var existingBeer = await repository.GetBeer(beer.Id).ConfigureAwait(false);
        if (existingBeer is not null)
        {
            throw new ConflictException($"Beer with id {beer.Id} already exists.");
        }

        if (string.IsNullOrWhiteSpace(beer.Name) 
            || string.IsNullOrWhiteSpace(beer.Description)
            || string.IsNullOrWhiteSpace(beer.Tagline)
            || (beer.FoodPairing is null || beer.FoodPairing.Count == 0)
            || string.IsNullOrWhiteSpace(beer.FirstBrewed))
        {
            throw new BadRequestException($"Beer info is not valid, missing or empty fields.");
        }
        var beerDb = beer.ToBeer();
        await repository.AddBeer(beerDb).ConfigureAwait(false);

        var ingredientsDb = BeerMapping.ToIngredients(beer.Ingredients);
        await repository.AddIngredient(ingredientsDb).ConfigureAwait(false);
        
        return 1;
    }
    
    public async Task<IEnumerable<BeerDto>> GetAllBeers()
    {
        var beersDb = await repository.GetAllBeers().ConfigureAwait(false);
        var beerDtos = beersDb.Select(b => b.ToBeerDto()).ToList();
        return beerDtos;
    }

    public async Task<BeerDto?> GetBeer(int id)
    {
        var existingBeer = await repository.GetBeer(id).ConfigureAwait(false);
        if (existingBeer is null)
        {
            throw new NotFoundException($"Beer with id {id} does not exist.");
        }
        var beerDto = existingBeer.ToBeerDto();
        var ingredients = await repository.GetIngredientsByBeerId(id).ConfigureAwait(false) 
                          ?? new Ingredients();
        beerDto.Ingredients = BeerMapping.ToIngredientsDto(ingredients);
        return beerDto;
    }

    public async Task<IEnumerable<BeerDto>> GetBeerByAbV(float abv)
    {
        var beersDb = await repository.GetBeerByAbV(abv).ConfigureAwait(false);
        var beerDtos = beersDb.Select(b => b.ToBeerDto()).ToList();
        return beerDtos;
    }

    public async Task<IngredientsDto?> GetIngredientsByBeerId(int beerId)
    {
        var ingredientsDb = await repository.GetIngredientsByBeerId(beerId).ConfigureAwait(false);
        if (ingredientsDb is null)
        {
            throw new NotFoundException($"Ingredients for beer with id {beerId} does not exist.");
        }

        return BeerMapping.ToIngredientsDto(ingredientsDb);
    }

    public async Task<IngredientsDto?> GetIngredientsByBeerName(string beerName)
    {
        var ingredientsDb = await repository.GetIngredientsByBeerName(beerName).ConfigureAwait(false);
        if (ingredientsDb is null)
        {
            throw new NotFoundException($"Ingredients for beer {beerName} does not exist.");
        }

        return BeerMapping.ToIngredientsDto(ingredientsDb);
    }
}
