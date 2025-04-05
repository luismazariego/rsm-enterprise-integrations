namespace DIYBeers.Domain.Entities;

public class Ingredients
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Malt> Malt { get; set; }
    public List<Hops> Hops { get; set; }
    public string Yeast { get; set; }

    public Beer Beer { get; set; }
    public Guid BeerId { get; set; }
}