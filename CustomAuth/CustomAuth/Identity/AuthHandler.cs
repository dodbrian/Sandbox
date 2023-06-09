using CustomAuth.Parsers;
using Microsoft.AspNetCore.Authorization;

namespace CustomAuth.Identity;

public class AuthHandler : AuthorizationHandler<AuthRequirement>
{
    private readonly RegexPolicyParser _regexPolicyParser;

    public AuthHandler(RegexPolicyParser regexPolicyParser) =>
        _regexPolicyParser = regexPolicyParser;

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthRequirement requirement)
    {
        var claims = context.User
            .FindAll(claim => claim.Type.Equals("Policy", StringComparison.OrdinalIgnoreCase));

        var claim = claims.FirstOrDefault();
        if (claim == null || !_regexPolicyParser.TryParse(claim.Value, out var claimPolicy))
            return Task.CompletedTask;

        if (requirement.Policy.Resource.Equals(claimPolicy.Resource, StringComparison.OrdinalIgnoreCase) &&
            requirement.Policy.Action.Equals(claimPolicy.Action, StringComparison.OrdinalIgnoreCase))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
