using MinimalAPIs_Example.DTOs;
using MinimalAPIs_Example.Repositories;
using Riok.Mapperly.Abstractions;

namespace MinimalAPIs_Example.Mapping;

[Mapper]
public partial class OrderMapper
{
    public partial OrderDto OrderToOrderDto(Order order);
    
    public partial List<OrderDto> OrdersToOrderDtos(List<Order> orders);
    
    public partial Order OrderInsertDtoToOrder(OrderInsertDto orderInsertDto);
    
    public partial List<Order> OrderInsertDtosToOrders(List<OrderInsertDto> orderInsertDtos);

    private DataType MapStringToDataType(string value) => DataType.FromString(value);
}