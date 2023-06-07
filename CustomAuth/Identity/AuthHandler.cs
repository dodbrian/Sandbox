using Microsoft.AspNetCore.Authorization;

namespace CustomAuth.Identity;

public class AuthHandler : AuthorizationHandler<AuthRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthRequirement requirement)
    {
        context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
