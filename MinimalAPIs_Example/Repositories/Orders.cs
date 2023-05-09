namespace MinimalAPIs_Example.Repositories;

public class Orders
{
    private List<Order> orders;

    public Orders()
    {
        orders = new List<Order>();
        SeedData();
    }
    
    public void Add(Order order)
    {
        orders.Add(order);
    }
    
    public List<Order> GetAllOrders()
    {
        return orders;
    }
    
    // ReSharper disable once MemberCanBePrivate.Global
    public Order GetOrder(int orderNumber)
    {
        return orders.FirstOrDefault(order => order.OrderNumber == orderNumber) ?? throw new InvalidOperationException();
    }
    
    public void DeleteOrder(int orderNumber)
    {
        orders.Remove(GetOrder(orderNumber));
    }
    
    public void UpdateOrder(Order order)
    {
        var orderToUpdate = GetOrder(order.OrderNumber);
        orderToUpdate.CustomerName = order.CustomerName;
        orderToUpdate.ProductName = order.ProductName;
        orderToUpdate.Quantity = order.Quantity;
    }

    private void SeedData()
    {
        orders.Add(new Order {OrderNumber = 1001, CustomerName = "John Joe", ProductName = "Widget A", Quantity = 11});
        orders.Add(new Order {OrderNumber = 1002, CustomerName = "Jane Smith", ProductName = "Widget B", Quantity = 22});
        orders.Add(new Order {OrderNumber = 1003, CustomerName = "Bob Johnson", ProductName = "Widget C", Quantity = 33});
        orders.Add(new Order {OrderNumber = 1004, CustomerName = "Bill Bob", ProductName = "Widget D", Quantity = 44});
        orders.Add(new Order {OrderNumber = 1005, CustomerName = "Barbie John", ProductName = "Widget E", Quantity = 55});
        orders.Add(new Order {OrderNumber = 1006, CustomerName = "Kimmy Hillminger", ProductName = "Widget F", Quantity = 66});
    }
}

public class Order
{
    public int OrderNumber { get; set; }
    public string? CustomerName { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
}