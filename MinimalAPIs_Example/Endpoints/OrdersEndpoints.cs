using MinimalAPIs_Example.Repositories;

namespace MinimalAPIs_Example.Endpoints;

public static class OrdersEndpoints
{
    public static RouteGroupBuilder MapOrders(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/orders");
        group.MapGet("/", (Orders orders) => orders.GetAllOrders());

        group.MapGet("/{orderNumber}", (int orderNumber, Orders orders) => orders.GetOrder(orderNumber));

        group.MapPost("/", (Order order, Orders orders) =>
        {
            orders.Add(order);
            return Results.Ok();
        });

        group.MapPost("/{orderNumber}", (int orderNumber, Order order, Orders orders) =>
        {
            order.OrderNumber = orderNumber;
            orders.UpdateOrder(order);
            return Results.Ok();
        });

        group.MapDelete("/{orderNumber}", (int orderNumber, Orders orders) =>
        {
            orders.DeleteOrder(orderNumber);
            return Results.Ok();
        });

        return group;
    }
    
}