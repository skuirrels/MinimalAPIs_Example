namespace MinimalAPIs_Example.Value_Objects;


public sealed class Weight : ValueObject
{
    public Weight()
    {
        
    }
    public Weight(decimal value, WeightType type)
    {
        Value = value;
        Type = type;
    }
    
    public decimal Value { get; private set; }

    public WeightType Type { get; private set; }
    
    public void SetWeight(decimal value, WeightType type)
    {
        Value = value;
        Type = type;
    }
    
    public string WeightUnit => Type.ToString();
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Type;
    }
}

public enum WeightType
{
    Kg =0,
    Lb =1
}