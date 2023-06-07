using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace CustomAuth.Identity;

public class ExpressionPolicyProvider : IAuthorizationPolicyProvider
{
    private readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider;

    public ExpressionPolicyProvider(IOptions<AuthorizationOptions> options) =>
        _fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (!policyName.Equals("Label:Read", StringComparison.OrdinalIgnoreCase))
            return _fallbackPolicyProvider.GetPolicyAsync(policyName);

        var authorizationPolicy = new AuthorizationPolicyBuilder()
            .AddRequirements(new AuthRequirement())
            .Build();

        return Task.FromResult<AuthorizationPolicy?>(authorizationPolicy);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => _fallbackPolicyProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => _fallbackPolicyProvider.GetFallbackPolicyAsync();
}
