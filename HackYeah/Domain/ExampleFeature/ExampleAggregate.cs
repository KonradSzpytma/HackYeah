namespace HackYeah.Domain.ExampleFeature;

public class ExampleAggregate(string name)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    private string _name  = name;
    private readonly List<string> _names = new();
    
    public void UpdateName(string name) 
        => _name = name;
    
    public List<string> GetNames() => _names;
    
    public void AddName(string name)
        => _names.Add(name);
}