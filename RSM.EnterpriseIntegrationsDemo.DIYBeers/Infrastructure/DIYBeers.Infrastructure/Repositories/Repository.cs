using DIYBeers.Domain.Entities;
using DIYBeers.Domain.Interfaces;
using DIYBeers.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DIYBeers.Infrastructure.Repositories;

public class Repository(AppDbContext context) : IRepository
{
    public async Task<int> AddBeer(Beer beer)
    {
        await context.Beers.AddAsync(beer).ConfigureAwait(false);
        await context.SaveChangesAsync();
        return beer.ExternalId;
    }
    
    public async Task<int> AddIngredient(Ingredients ingredient)
    {
        await context.Malts.AddRangeAsync(ingredient.Malt);
        
        await context.Hops.AddRangeAsync(ingredient.Hops);
        
        await context.Ingredients.AddAsync(ingredient).ConfigureAwait(false);
        
        return await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Beer>> GetAllBeers()
    {
        return await context.Set<Beer>()
            .Include(b => b.Ingredients)
            .Include(i => i.Ingredients.Hops)
            .Include(i => i.Ingredients.Malt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Beer?> GetBeer(int id)
    {
        return await context
            .Set<Beer>()
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.ExternalId == id)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<Beer>> GetBeerByAbV(float abv)
    {
        return await context
            .Set<Beer>()
            .Include(b => b.Ingredients)
            .Include(i => i.Ingredients.Hops)
            .Include(i => i.Ingredients.Malt)
            .AsNoTracking()
            .Where(b => b.Abv >= abv)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<Ingredients?> GetIngredientsByBeerId(int beerId)
    {
        return await context
            .Set<Ingredients>()
            .AsNoTracking()
            .Where(i => i.Beer.ExternalId == beerId)
            .FirstOrDefaultAsync();
    }

    public async Task<Ingredients?> GetIngredientsByBeerName(string beerName)
    {
        return await context
            .Set<Ingredients>()
            .AsNoTracking()
            .Where(i => i.Beer.Name == beerName)
            .FirstOrDefaultAsync();
    }
}
