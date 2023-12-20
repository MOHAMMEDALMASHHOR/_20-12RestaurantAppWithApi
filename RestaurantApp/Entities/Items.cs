namespace Entities;

public class Items
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
    public Category Categories { get; set; }
}
