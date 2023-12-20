namespace Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<Items> Items { get; set; }
    public DateTime OrderDate => DateTime.Now;
    public Order()
    {
        Items= new List<Items>();
    }
}