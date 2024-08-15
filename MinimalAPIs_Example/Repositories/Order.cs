namespace MinimalAPIs_Example.Repositories;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int OrderNumber { get; set; }
    public string? CustomerName { get; set; }
    public string? ProductName { get; set; }
    public OrderState State { get; set; } = OrderState.New;
    public string StateName => State.ToString();
    public DateTime CreatedDateTime { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedDateTime { get; private set; } = DateTime.UtcNow;
    public int TotalQuantity => OrderLines.Sum(orderLine => orderLine.Quantity);
    public List<CustomField> CustomFields { get; set; } = [];
    public List<OrderLine> OrderLines { get; set; } = [];
}

public class OrderLine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int LineNumber { get; set; }
    public string? Product { get; set; }
    public int Quantity { get; set; }
}

public enum OrderState
{
    New = 1,
    Processing = 2,
    Shipped = 3,
    Delivered = 4
}