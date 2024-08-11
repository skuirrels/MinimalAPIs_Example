namespace MinimalAPIs_Example;

public class CustomField
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Value { get; set; }
    public DataType Type { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDateTime { get; set; } = DateTime.UtcNow;
}

public class DataType
{
    public static readonly DataType String = new DataType("String");
    public static readonly DataType Integer = new DataType("Integer");
    public static readonly DataType Decimal = new DataType("Decimal");
    public static readonly DataType DateTime = new DataType("DateTime");
    public static readonly DataType Bool = new DataType("Bool");

    public string Value { get; }

    public DataType(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
    
    public static DataType FromString(string value)
    {
        return value switch
        {
            "String" => String,
            "Integer" => Integer,
            "Decimal" => Decimal,
            "DateTime" => DateTime,
            "Bool" => Bool,
            _ => throw new ArgumentException($"Unknown DataType value: {value}")
        };
    }
}
