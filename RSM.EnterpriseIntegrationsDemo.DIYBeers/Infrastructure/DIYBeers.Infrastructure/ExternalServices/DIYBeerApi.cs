using System.Net.Http.Json;
using DIYBeers.Domain.Interfaces.ExternalServices;
using DIYBeers.Domain.Models;

namespace DIYBeers.Infrastructure.ExternalServices;

public class DIYBeerApi(HttpClient httpClient) : IDiyBeerApi
{
    public async Task<List<Beer>?> GetBeerDetails(int page=1, int perPage=10, string search="")
    {
        return await httpClient.GetFromJsonAsync<List<Beer>>
            ($"?page={page}&per_page={perPage}&food={search}");
    }
}