using System.Text.Json.Serialization;

namespace MinimalAPIs_Example.DTOs;

public record CustomFieldDto
{
    //public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public string Type { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDateTime { get; set; }
}

public record CustomFieldInsertDto
{
    public string Name { get; set; }
    public string Value { get; set; }
    public DataType Type { get; set; }
}