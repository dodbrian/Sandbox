using CustomAuth.Parsers;
using Microsoft.AspNetCore.Authorization;

namespace CustomAuth.Identity;

public class AuthHandler : AuthorizationHandler<AuthRequirement>
{
    private readonly SemanticPolicyParser _semanticPolicyParser;

    public AuthHandler(SemanticPolicyParser semanticPolicyParser) =>
        _semanticPolicyParser = semanticPolicyParser;

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthRequirement requirement)
    {
        var claims = context.User
            .FindAll(claim => claim.Type.Equals("Policy", StringComparison.OrdinalIgnoreCase));

        var claim = claims.FirstOrDefault();
        if (claim == null || !_semanticPolicyParser.TryParse(claim.Value, out var claimPolicy))
            return Task.CompletedTask;

        var firstPermission = requirement.Policy.Permissions.First();
        var firstClaimPermission = claimPolicy.Permissions.First();

        if (firstPermission.Resource.Equals(firstClaimPermission.Resource, StringComparison.OrdinalIgnoreCase) &&
            firstPermission.Operations[0]
                .Name.Equals(firstClaimPermission.Operations[0].Name, StringComparison.OrdinalIgnoreCase))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
