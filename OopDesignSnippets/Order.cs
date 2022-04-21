namespace OopDesignSnippets;

public class Order
{
    private readonly List<OrderItem> _orderItems = new();

    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public void CreateOrderItem(string name, decimal quantity, decimal price)
    {
        var orderItem = new OrderItem(name, quantity, price);
        _orderItems.Add(orderItem);
    }

    public void CreateOrderItem(OrderItemCreationModel orderItem)
    {
        CreateOrderItem(orderItem.Name!, orderItem.Quantity, orderItem.Price);
    }

    public void AddExistingOrderItem(OrderItem orderItem) => _orderItems.Add(orderItem);
}