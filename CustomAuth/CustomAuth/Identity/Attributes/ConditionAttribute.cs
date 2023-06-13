namespace CustomAuth.Identity.Attributes;

[AttributeUsage(AttributeTargets.Parameter)]
public class ConditionAttribute : Attribute
{
    public string ConditionName { get; }

    public ConditionAttribute(string conditionName) => ConditionName = conditionName;
}
