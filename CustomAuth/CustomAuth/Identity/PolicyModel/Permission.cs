namespace CustomAuth.Identity.PolicyModel;

public class Permission
{
    public string Resource { get; init; }
    public List<Operation> Operations { get; init; }
    public List<Permission> Children { get; init; }
}
