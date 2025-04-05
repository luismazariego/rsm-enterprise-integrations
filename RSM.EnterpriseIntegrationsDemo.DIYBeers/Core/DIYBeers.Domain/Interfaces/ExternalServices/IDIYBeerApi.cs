using DIYBeers.Domain.Models;

namespace DIYBeers.Domain.Interfaces.ExternalServices;

public interface IDiyBeerApi
{
    Task<List<Beer>?> GetBeerDetails(int page, int perPage, string search);
}