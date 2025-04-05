namespace DIYBeers.Application.DTOs;

public class IngredientsDto
{
    public int Id { get; set; }
    public List<MaltDto> Malt { get; set; }
    public List<HopsDto> Hops { get; set; }
    public string Yeast { get; set; }
}