namespace Glasno.Case.Aggregator.Domain.Cases.ValueObjects;

public class Side
{
    public string Name { get; init; }
    public SideType Type { get; init; }

    public void Deconstruct(out string Name, out SideType Type)
    {
        Name = this.Name;
        Type = this.Type;
    }
}