namespace MinimalAPIs_Example.Value_Objects;


public sealed class Volume : ValueObject
{
    public Volume(decimal value, VolumeType type)
    {
        Value = value;
        Type = type;
    }
    
    public decimal Value { get; }

    public VolumeType Type { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Type;
    }

    public string VolumeUnit => Type.ToString();
}

public enum VolumeType
{
    M3 =0,
    F3 =1
}