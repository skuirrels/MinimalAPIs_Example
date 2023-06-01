using System.Runtime.CompilerServices;

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
        return orders.FirstOrDefault(order => order.OrderNumber == orderNumber)!;
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
        orders.Add(new Order {OrderNumber = 1001, CustomerName = "John Joe", ProductName = "Widget A", Quantity = 11, State = OrderState.New, OrderLines = new List<OrderLine>
        {
            new OrderLine {LineNumber = 1, Product = "Widget A1"},
            new OrderLine {LineNumber = 2, Product = "Widget A2"}
        }});
        orders.Add(new Order {OrderNumber = 1002, CustomerName = "Jane Smith", ProductName = "Widget B", Quantity = 22, State = OrderState.Processing, OrderLines = new List<OrderLine>
        {
            new OrderLine {LineNumber = 1, Product = "Widget B1"},
            new OrderLine {LineNumber = 2, Product = "Widget B2"},
            new OrderLine {LineNumber = 3, Product = "Widget B3"}
        }});
        orders.Add(new Order {OrderNumber = 1003, CustomerName = "Bob Johnson", ProductName = "Widget C", Quantity = 33, State = OrderState.Delivered });
        orders.Add(new Order {OrderNumber = 1004, CustomerName = "Bill Bob", ProductName = "Widget D", Quantity = 44, State = OrderState.Delivered});
        orders.Add(new Order {OrderNumber = 1005, CustomerName = "Barbie John", ProductName = "Widget E", Quantity = 55, State = OrderState.Delivered});
        orders.Add(new Order {OrderNumber = 1006, CustomerName = "Kimmy Hillminger", ProductName = "Widget F", Quantity = 66, State = OrderState.Delivered});
        orders.Add(new Order {OrderNumber = 1007, CustomerName = "Kenny Rogers", ProductName = "Widget G", Quantity = 77, State = OrderState.Delivered, OrderLines = new List<OrderLine>
        {
            new OrderLine {LineNumber = 1, Product = "Widget G1"},
            new OrderLine {LineNumber = 2, Product = "Widget G2"},
        }});
    }
}

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int OrderNumber { get; set; }
    public string? CustomerName { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
    public OrderState State { get; set; } = OrderState.New;
    public string StateName => State.ToString();
    
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public List<OrderLine> OrderLines { get; set; } = new();
}

public class OrderLine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int LineNumber { get; set; }
    public string? Product { get; set; }
}

public enum OrderState
{
    New = 1,
    Processing = 2,
    Shipped = 3,
    Delivered = 4
}
