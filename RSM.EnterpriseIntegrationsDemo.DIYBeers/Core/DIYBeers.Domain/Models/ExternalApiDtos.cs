using System.Text.Json.Serialization;

namespace DIYBeers.Domain.Models;

public class Beer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tagline { get; set; }
    [JsonPropertyName("first_brewed")]
    public string FirstBrewed { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public double Abv { get; set; }
    public double Ibu { get; set; }
    [JsonPropertyName("target_fg")]
    public double TargetFg { get; set; }
    [JsonPropertyName("target_og")]
    public double TargetOg { get; set; }
    public double Ebc { get; set; }
    public double Srm { get; set; }
    public double Ph { get; set; }
    [JsonPropertyName("attenuation_level")]
    public double AttenuationLevel { get; set; }
    public Volume Volume { get; set; }
    public Volume BoilVolume { get; set; }
    public Method Method { get; set; }
    public Ingredients Ingredients { get; set; }
    [JsonPropertyName("food_pairing")]
    public List<string> FoodPairing { get; set; }
    [JsonPropertyName("brewers_tips")]
    public string BrewersTips { get; set; }
    public string ContributedBy { get; set; }
}

public class Volume
{
    public double Value { get; set; }
    public string Unit { get; set; }
}

public class Method
{
    public List<MashTemp> MashTemp { get; set; }
    public Fermentation Fermentation { get; set; }
    public string Twist { get; set; }
}

public class MashTemp
{
    public Temperature Temp { get; set; }
    public int Duration { get; set; }
}

public class Fermentation
{
    public Temperature Temp { get; set; }
}

public class Temperature
{
    public double Value { get; set; }
    public string Unit { get; set; }
}

public class Ingredients
{
    public List<Malt> Malt { get; set; }
    public List<Hops> Hops { get; set; }
    public string Yeast { get; set; }
}

public class Malt
{
    public string Name { get; set; }
    public Amount Amount { get; set; }
}

public class Hops
{
    public string Name { get; set; }
    public Amount Amount { get; set; }
    public string Add { get; set; }
    public string Attribute { get; set; }
}

public class Amount
{
    public double Value { get; set; }
    public string Unit { get; set; }
}

