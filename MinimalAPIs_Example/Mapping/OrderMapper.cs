using Mapster;
using MinimalAPIs_Example.DTOs;
using MinimalAPIs_Example.Repositories;

namespace MinimalAPIs_Example.Mapping;

public class OrderMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Order, DTOs.OrderDto>()
            //.Ignore(dest => dest.Id); // .Ignore does not work due to a bug. 
            //.Ignore(dest => dest.CustomerName);
            //.Map(dest => dest.OrderNumber, src => src.Id) // Will error due to type.  
            .Map(dest => dest.CustomerName, src => src.ProductName)
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.OrderLines, src => src.OrderLines)
            .Map(dest => dest.State, src => src.State.ToString());
        //.Compile();

        config.NewConfig<OrderLine, OrderLineDto>();
        //.Compile();
    }
}