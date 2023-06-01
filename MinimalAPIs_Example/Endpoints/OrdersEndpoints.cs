using Mapster;
using Microsoft.AspNetCore.Mvc;
using MinimalAPIs_Example.DTOs;
using MinimalAPIs_Example.Repositories;

namespace MinimalAPIs_Example.Endpoints;

public static class OrdersEndpoints
{
    public static RouteGroupBuilder MapOrders(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/orders")
            .WithParameterValidation();
        
        // group.MapGet("/", (Orders orders) => orders.GetAllOrders());
        // group.MapGet("/", (Orders orders) => orders.GetAllOrders().Adapt<List<OrderDto>>());
        group.MapGet("/", (Orders orders) =>
        {
            var orderDtos = orders.GetAllOrders().Adapt<List<OrderDto>>();
            return Results.Ok(orderDtos);
        });

        group.MapGet("/{orderNumber}", (int orderNumber, Orders orders) =>
            {
                return orders.GetOrder(orderNumber).Adapt<OrderDto>();
            })
            .WithName("GetByNumber");

        // group.MapGet("/{orderNumber}", (int orderNumber) => Results.NotFound())
        //     .Produces<NotFoundResult>(404);

        group.MapPost("/", (Order order, Orders orders) =>
        {
            orders.Add(order);
            return Results.CreatedAtRoute("GetByNumber", new {order.OrderNumber}, order);
        });

        group.MapPut("/{orderNumber}", (int orderNumber, Order updatedOrder, Orders orders) =>
        {
            orders.UpdateOrder(updatedOrder);
            return Results.AcceptedAtRoute("GetByNumber", new {updatedOrder.OrderNumber}, updatedOrder);
        });

        group.MapDelete("/{orderNumber}", (int orderNumber, Orders orders) =>
        {
            orders.DeleteOrder(orderNumber);
            return Results.Ok();
        });

        return group;
    }
    
}