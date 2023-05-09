using MinimalAPIs_Example.Repositories;

namespace MinimalAPIs_Example.Endpoints;

public static class OrdersEndpoints
{
    public static RouteGroupBuilder MapOrders(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/orders");
        group.MapGet("/", (Orders orders) => orders.GetAllOrders());

        group.MapGet("/{orderNumber}", (int orderNumber, Orders orders) => orders.GetOrder(orderNumber))
            .WithName("GetByNumber");

        group.MapPost("/", (Order order, Orders orders) =>
        {
            orders.Add(order);
            return Results.CreatedAtRoute("GetByNumber", new {order.OrderNumber}, order);
        });

        group.MapDelete("/{orderNumber}", (int orderNumber, Orders orders) =>
        {
            orders.DeleteOrder(orderNumber);
            return Results.Ok();
        });

        return group;
    }
    
}