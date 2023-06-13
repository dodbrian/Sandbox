using CustomAuth.Identity.Parsers;
using CustomAuth.Identity.PolicyModel;
using Microsoft.AspNetCore.Authorization;

namespace CustomAuth.Identity;

public class SemanticAuthHandler : AuthorizationHandler<SemanticAuthRequirement>
{
    private readonly SemanticPolicyParser _semanticPolicyParser;
    private readonly SemanticPolicyEvaluator _semanticPolicyEvaluator;

    public SemanticAuthHandler(
        SemanticPolicyParser semanticPolicyParser,
        SemanticPolicyEvaluator semanticPolicyEvaluator)
    {
        _semanticPolicyParser = semanticPolicyParser;
        _semanticPolicyEvaluator = semanticPolicyEvaluator;
    }

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        SemanticAuthRequirement requirement)
    {
        var actionConditions = context.Resource as Dictionary<string, (string argumentName, object? argumentValue)>;
        var claimPolicies = context.User
            .FindAll(claim => claim.Type.Equals("Policy", StringComparison.OrdinalIgnoreCase))
            .Select(
                claim => _semanticPolicyParser.TryParse(claim.Value, out var claimPolicy)
                    ? claimPolicy
                    : Policy.NullPolicy);

        if (_semanticPolicyEvaluator.PolicyIsFulfilled(
                requirement.Policy,
                claimPolicies,
                actionConditions ?? new Dictionary<string, (string argumentName, object? argumentValue)>()))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
