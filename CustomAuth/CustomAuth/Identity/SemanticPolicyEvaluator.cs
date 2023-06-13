using CustomAuth.Identity.PolicyModel;

namespace CustomAuth.Identity;

public class SemanticPolicyEvaluator
{
    public bool PolicyIsFulfilled(
        Policy requirementPolicy,
        IEnumerable<Policy> claimPolicies,
        IDictionary<string, (string argumentName, object? argumentValue)> actionConditions)
    {
        var lookup = claimPolicies.SelectMany(policy => policy.Permissions).ToLookup(permission => permission.Resource);

        var isFulfilled = requirementPolicy.Permissions.All(
            requirementPermission =>
            {
                var claimPermissions = lookup[requirementPermission.Resource];
                return requirementPermission.Operations.TrueForAll(
                    operation =>
                        claimPermissions.Any(
                            claimPermission => claimPermission.Operations.Exists(
                                claimOperation => claimOperation.Name.Equals(
                                                      operation.Name,
                                                      StringComparison.OrdinalIgnoreCase) &&
                                                  ConditionsAreFulfilled(
                                                      claimOperation.Conditions,
                                                      actionConditions))));
            });

        return isFulfilled;
    }

    private bool ConditionsAreFulfilled(
        List<Condition> claimConditions,
        IDictionary<string, (string argumentName, object? argumentValue)> actionConditions) =>
        claimConditions.TrueForAll(
            claimCondition => actionConditions.TryGetValue(claimCondition.Name, out var actionArgument) &&
                              claimCondition.Value.Equals(
                                  actionArgument.argumentValue?.ToString(),
                                  StringComparison.OrdinalIgnoreCase));
}
