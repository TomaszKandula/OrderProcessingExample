namespace OrderProcessing.Domain;

public class Order
{
    public int Id { get; set; }

    public string Description { get; set; } = string.Empty;
}