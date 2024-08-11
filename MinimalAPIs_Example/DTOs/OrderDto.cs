using MinimalAPIs_Example.Repositories;

namespace MinimalAPIs_Example.DTOs;

public record OrderDto(
    //Guid Id,
    int OrderNumber,
    string? CustomerName,
    string? ProductName,
    int Quantity,
    List<OrderLineDto>? OrderLines,
    List<CustomFieldDto>? CustomFields,
    OrderState State,
    string? StateName);

public record OrderInsertDto(
    int OrderNumber,
    string? CustomerName,
    string? ProductName,
    int Quantity,
    List<OrderLineDto>? OrderLines,
    List<CustomFieldDto>? CustomFields);

public record OrderLineDto(
    //Guid Id,
    int LineNumber,
    string? Product);