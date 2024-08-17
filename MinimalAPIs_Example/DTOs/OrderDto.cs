using MinimalAPIs_Example.Repositories;

namespace MinimalAPIs_Example.DTOs;

public record OrderDto(
    //Guid Id,
    int OrderNumber,
    string? CustomerName,
    string? ProductName,
    List<OrderLineDto>? OrderLines,
    List<CustomFieldDto>? CustomFields,
    OrderState State,
    string? StateName,
    decimal TotalWeight,
    int TotalQuantity,
    DateTime CreatedDateTime,
    DateTime? UpdatedDateTime);

public record OrderInsertDto(
    int OrderNumber,
    string? CustomerName,
    string? ProductName,
    List<OrderLineDto>? OrderLines,
    List<CustomFieldDto>? CustomFields);

public record OrderUpdateDto(
    int OrderNumber,
    string? CustomerName,
    string? ProductName,
    List<OrderLineDto>? OrderLines,
    List<CustomFieldDto>? CustomFields);

public record OrderLineDto(
    //Guid Id,
    int LineNumber,
    string? Product,
    int Quantity,
    WeightDto? Weight,
    VolumeDto? Volume);