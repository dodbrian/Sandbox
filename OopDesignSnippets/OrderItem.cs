namespace OopDesignSnippets;

public class OrderItem
{
    public OrderItem(string name, decimal quantity, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public Guid Id { get; }
    public string Name { get; }
    public decimal Quantity { get; }
    public decimal Price { get; }
}