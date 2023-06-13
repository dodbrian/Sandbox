using CustomAuth.Identity.Parsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace CustomAuth.Identity.Providers;

public class SemanticPolicyProvider : IAuthorizationPolicyProvider
{
    private readonly SemanticPolicyParser _semanticPolicyParser;
    private readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider;

    public SemanticPolicyProvider(
        IOptions<AuthorizationOptions> options,
        SemanticPolicyParser semanticPolicyParser)
    {
        _semanticPolicyParser = semanticPolicyParser;
        _fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
    }

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (!_semanticPolicyParser.TryParse(policyName, out var semanticPolicy))
            return _fallbackPolicyProvider.GetPolicyAsync(policyName);

        var authorizationPolicy = new AuthorizationPolicyBuilder()
            .AddRequirements(new SemanticAuthRequirement(semanticPolicy))
            .Build();

        return Task.FromResult<AuthorizationPolicy?>(authorizationPolicy);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => _fallbackPolicyProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => _fallbackPolicyProvider.GetFallbackPolicyAsync();
}
