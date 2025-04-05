namespace DIYBeers.Domain.Entities;

public class Beer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public int ExternalId { get; set; }
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
    public Ingredients Ingredients { get; set; }
    public Guid IngredientsId { get; set; }
    public string FoodPairing { get; set; }
    public string BrewersTips { get; set; }
}