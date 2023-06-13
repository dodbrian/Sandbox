namespace CustomAuth.Identity.PolicyModel;

public record Policy(IEnumerable<Permission> Permissions)
{
    public static readonly Policy NullPolicy = new(Enumerable.Empty<Permission>());
}
