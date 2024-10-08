﻿using System.Runtime.CompilerServices;

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
    }

    private void SeedData()
    {
        orders.Add(new Order
        {
            OrderNumber = 1001, CustomerName = "John Joe", ProductName = "Widget A",
            State = OrderState.New, 
            OrderLines = new List<OrderLine>
            {
                new OrderLine { LineNumber = 1, Product = "Widget A1", Quantity = 11},
                new OrderLine { LineNumber = 2, Product = "Widget A2", Quantity = 22}
            },
            CustomFields = new List<CustomField>
            {
                new CustomField { Name = "Warranty", Value = "3", Type = DataType.Integer },
                new CustomField { Name = "Warranty", Value = "2", Type = DataType.Decimal }
            }
        });
        orders.Add(new Order
        {
            OrderNumber = 1002, CustomerName = "Jane Smith", ProductName = "Widget B",
            State = OrderState.Processing, 
            OrderLines = new List<OrderLine>
            {
                new OrderLine { LineNumber = 1, Product = "Widget B1", Quantity = 33},
                new OrderLine { LineNumber = 2, Product = "Widget B2", Quantity = 44},
                new OrderLine { LineNumber = 3, Product = "Widget B3", Quantity = 55}
            },
            CustomFields = new List<CustomField>
            {
                new CustomField { Name = "Weight", Value = "2kg", Type = DataType.String },
                new CustomField { Name = "Material", Value = "Plastic", Type = DataType.String }
            }
        });
        orders.Add(new Order
        {
            OrderNumber = 1003, CustomerName = "Bob Johnson", ProductName = "Widget C",
            State = OrderState.Delivered
        });
        orders.Add(new Order
        {
            OrderNumber = 1004, CustomerName = "Bill Bob", ProductName = "Widget D",
            State = OrderState.Delivered
        });
        orders.Add(new Order
        {
            OrderNumber = 1005, CustomerName = "Barbie John", ProductName = "Widget E",
            State = OrderState.Delivered
        });
        orders.Add(new Order
        {
            OrderNumber = 1006, CustomerName = "Kimmy Hillminger", ProductName = "Widget F",
            State = OrderState.Shipped
        });
        orders.Add(new Order
        {
            OrderNumber = 1007, CustomerName = "Kenny Rogers", ProductName = "Widget G",
            State = OrderState.Delivered, 
            OrderLines = new List<OrderLine>
            {
                new OrderLine { LineNumber = 1, Product = "Widget G1", Quantity = 66},
                new OrderLine { LineNumber = 2, Product = "Widget G2", Quantity = 77},
            },
            CustomFields = new List<CustomField>
            {
                new CustomField { Name = "Warranty", Value = "3", Type = DataType.Integer },
                new CustomField { Name = "Warranty", Value = "2", Type = DataType.Decimal }
            }
        });
    }
}

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