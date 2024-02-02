namespace Glasno.Case.Aggregator.Domain.Cases.ValueObjects;

public class Plaintiff
{
    public string Name { get; init; }
    public string Address { get; init; }
    public string Inn { get; init; }

    public void Deconstruct(out string Name, out string Address, out string Inn)
    {
        Name = this.Name;
        Address = this.Address;
        Inn = this.Inn;
    }
}