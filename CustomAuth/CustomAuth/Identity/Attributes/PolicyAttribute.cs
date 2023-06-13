namespace CustomAuth.Identity.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class PolicyAttribute : Attribute
{
    public string Policy { get; }

    public PolicyAttribute(string policy) => Policy = policy;
}
