namespace Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public List<Items> Items { get; set; }
    public Category()
    {
        Items = new List<Items>();
    }
}