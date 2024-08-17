using MinimalAPIs_Example.DTOs;
using MinimalAPIs_Example.Repositories;
using MinimalAPIs_Example.Value_Objects;
using Riok.Mapperly.Abstractions;

namespace MinimalAPIs_Example.Mapping;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public partial class OrderMapper
{
    public partial OrderDto OrderToOrderDto(Order order);
    
    public partial List<OrderDto> OrdersToOrderDtos(List<Order> orders);
    
    public partial Order OrderInsertDtoToOrder(OrderInsertDto orderInsertDto);
    
    public partial List<Order> OrderInsertDtosToOrders(List<OrderInsertDto> orderInsertDtos);

    private DataType MapStringToDataType(string value) => DataType.FromString(value);
    
    private string MapDataTypeToString(DataType dataType) => dataType.ToString();

    public partial WeightDto WeightToWeightDto(Weight weight);

    public partial Weight WeightDtoToWeight(WeightDto weightDto);
    
    public partial VolumeDto VolumeToVolumeDto(Volume volume);
    
    public partial Volume VolumeDtoToVolume(VolumeDto volumeDto);
    
}