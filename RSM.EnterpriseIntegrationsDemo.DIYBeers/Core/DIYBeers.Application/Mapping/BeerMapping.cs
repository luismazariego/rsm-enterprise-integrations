using DIYBeers.Application.DTOs;
using DIYBeers.Domain.Entities;

namespace DIYBeers.Application.Mapping;

public static class BeerMapping
{
    public static Beer ToBeer(this BeerDto beerDto)
    {
        var beer = new Beer
        {
            ExternalId = beerDto.Id,
            Name = beerDto.Name,
            Description = beerDto.Description,
            FoodPairing = string.Join(", ", beerDto.FoodPairing.Where(s => !string.IsNullOrWhiteSpace(s))),
            Abv = beerDto.Abv,
            Ebc = beerDto.Ebc,
            Ph = beerDto.Ph,
            Ibu = beerDto.Ibu,
            Tagline = beerDto.Tagline,
            AttenuationLevel = beerDto.AttenuationLevel,
            BrewersTips = beerDto.BrewersTips,
            FirstBrewed = beerDto.FirstBrewed,
            Srm = beerDto.Srm,
            TargetFg = beerDto.TargetFg,
            TargetOg = beerDto.TargetOg
        };
        return beer;
    }
    
    public static BeerDto ToBeerDto(this Beer beer)
    {
        var beerDto = new BeerDto
        {
            Id = beer.ExternalId,
            Name = beer.Name,
            Description = beer.Description,
            FoodPairing = beer.FoodPairing.Split(", ").ToList(),
            Abv = beer.Abv,
            Ebc = beer.Ebc,
            Ph = beer.Ph,
            Ibu = beer.Ibu,
            Tagline = beer.Tagline,
            AttenuationLevel = beer.AttenuationLevel,
            BrewersTips = beer.BrewersTips,
            FirstBrewed = beer.FirstBrewed,
            Srm = beer.Srm,
            TargetFg = beer.TargetFg,
            TargetOg = beer.TargetOg,
            Ingredients = ToIngredientsDto(beer.Ingredients)
        };
        return beerDto;
    }

    private static HopsDto ToHopsDto(Hops hops)
    {
        return new HopsDto
        {
            Name = hops.Name,
            Unit = hops.Unit,
            Value = hops.Value,
            Add = hops.Add,
            Attribute = hops.Attribute
        };
    }

    private static Hops ToHops(HopsDto hopsDto)
    {
        return new Hops
        {
            Name = hopsDto.Name,
            Unit = hopsDto.Unit,
            Value = hopsDto.Value,
            Add = hopsDto.Add,
            Attribute = hopsDto.Attribute
        };
    }

    private static Malt ToMalt(MaltDto maltDto)
    {
        return new Malt
        {
            Name = maltDto.Name,
            Unit = maltDto.Unit,
            Value = maltDto.Value
        };
    }

    private static MaltDto ToMaltDto(Malt malt)
    {
        return new MaltDto
        {
            Name = malt.Name,
            Unit = malt.Unit,
            Value = malt.Value
        };
    }
    
    public static IngredientsDto ToIngredientsDto(Ingredients ingredients)
    {
        return new IngredientsDto
        {
            Malt = ingredients.Malt.Select(ToMaltDto).ToList(),
            Hops = ingredients.Hops.Select(ToHopsDto).ToList(),
            Yeast = ingredients.Yeast
        };
    }
    
    public static Ingredients ToIngredients(IngredientsDto ingredientsDto)
    {
        return new Ingredients
        {
            Malt = ingredientsDto.Malt.Select(ToMalt).ToList(),
            Hops = ingredientsDto.Hops.Select(ToHops).ToList(),
            Yeast = ingredientsDto.Yeast
        };
    }

    public static BeerDto ToBeerDto(this DIYBeers.Domain.Models.Beer beer)
    {
        var beerDto = new BeerDto
        {
            Id = beer.Id,
            Name = beer.Name,
            Description = beer.Description,
            FoodPairing = beer.FoodPairing,
            Abv = beer.Abv,
            Ebc = beer.Ebc,
            Ph = beer.Ph,
            Ibu = beer.Ibu,
            Tagline = beer.Tagline,
            AttenuationLevel = beer.AttenuationLevel,
            BrewersTips = beer.BrewersTips,
            FirstBrewed = beer.FirstBrewed,
            Srm = beer.Srm,
            TargetFg = beer.TargetFg,
            TargetOg = beer.TargetOg,
            Ingredients = beer.Ingredients.ToIngredientsDto()
        };
        return beerDto;
    }

    private static MaltDto ToMaltDto(this DIYBeers.Domain.Models.Malt malt)
    {
        return new MaltDto
        {
            Name = malt.Name,
            Value = (float)malt.Amount.Value,
            Unit = malt.Amount.Unit,
        };
    }

    private static HopsDto ToHopsDto(this DIYBeers.Domain.Models.Hops hops)
    {
        return new HopsDto
        {
            Attribute = hops.Attribute,
            Add = hops.Add,
            Name = hops.Name,
            Unit = hops.Amount.Unit,
            Value = (float)hops.Amount.Value,
        };
    }

    private static IngredientsDto ToIngredientsDto(this DIYBeers.Domain.Models.Ingredients ingredients)
    {
        return new IngredientsDto
        {
            Yeast = ingredients.Yeast,
            Malt = ingredients.Malt.Select(ToMaltDto).ToList(),
            Hops = ingredients.Hops.Select(ToHopsDto).ToList(),
        };
    }
}
