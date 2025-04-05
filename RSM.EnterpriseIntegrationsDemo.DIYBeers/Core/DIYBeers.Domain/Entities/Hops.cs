namespace DIYBeers.Domain.Entities;

public class Hops
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Unit { get; set; }
    public float Value { get; set; }   
    public string Add { get; set; }
    public string Attribute { get; set; }

    public Guid IngredientsId { get; set; }
}