using Microsoft.AspNetCore.Mvc;
using MinimalAPIs_Example.DTOs;
using MinimalAPIs_Example.Mapping;
using MinimalAPIs_Example.Repositories;
using Riok.Mapperly.Abstractions;

namespace MinimalAPIs_Example.Endpoints;

public static class OrdersEndpoints
{
    public static RouteGroupBuilder MapOrders(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/orders")
            .WithParameterValidation();
        
        // group.MapGet("/", (Orders orders) => orders.GetAllOrders());
        // group.MapGet("/", (Orders orders) => orders.GetAllOrders().Adapt<List<OrderDto>>());
        group.MapGet("/", (Orders orders, [FromServices] OrderMapper mapper) =>
        {
            // var orderDtos = orders.GetAllOrders().Adapt<List<OrderDto>>();
            var orderDtos = mapper.OrdersToOrderDtos(orders.GetAllOrders());
            
            return Results.Ok(orderDtos);
        });

        group.MapGet("/{orderNumber}", (int orderNumber, Orders orders, [FromServices] OrderMapper mapper) =>
            {
                var order = orders.GetOrder(orderNumber);
                var orderDto = mapper.OrderToOrderDto(order);
                return Results.Ok(orderDto);
            })
            .WithName("GetByNumber");
        

        group.MapPost("/", (OrderInsertDto orderInsertDto, Orders orders, [FromServices] OrderMapper mapper) =>
        {
            var order = mapper.OrderInsertDtoToOrder(orderInsertDto);
            orders.Add(order);
            var orderDto = mapper.OrderToOrderDto(order);
            return Results.CreatedAtRoute("GetByNumber", new { order.OrderNumber }, orderDto);
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