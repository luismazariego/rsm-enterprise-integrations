namespace DIYBeers.Application.DTOs;

public class BeerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tagline { get; set; }
    public string FirstBrewed { get; set; }
    public string Description { get; set; }
    public double Abv { get; set; }
    public double Ibu { get; set; }
    public double TargetFg { get; set; }
    public double TargetOg { get; set; }
    public double Ebc { get; set; }
    public double Srm { get; set; }
    public double Ph { get; set; }
    public double AttenuationLevel { get; set; }
    public IngredientsDto Ingredients { get; set; }
    public List<string> FoodPairing { get; set; }
    public string BrewersTips { get; set; }
}