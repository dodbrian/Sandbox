namespace CustomAuth.Identity.PolicyModel;

public class Operation
{
    public string Name { get; init; }
    public List<Condition> Conditions { get; init; }
}
