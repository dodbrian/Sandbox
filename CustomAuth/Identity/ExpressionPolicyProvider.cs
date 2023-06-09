using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace CustomAuth.Identity;

public class ExpressionPolicyProvider : IAuthorizationPolicyProvider
{
    private readonly RegexPolicyParser _regexPolicyParser;
    private readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider;

    public ExpressionPolicyProvider(
        IOptions<AuthorizationOptions> options,
        RegexPolicyParser regexPolicyParser)
    {
        _regexPolicyParser = regexPolicyParser;
        _fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
    }

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (!_regexPolicyParser.TryParse(policyName, out var expressionPolicy))
            return _fallbackPolicyProvider.GetPolicyAsync(policyName);

        var authorizationPolicy = new AuthorizationPolicyBuilder()
            .AddRequirements(new AuthRequirement(expressionPolicy))
            .Build();

        return Task.FromResult<AuthorizationPolicy?>(authorizationPolicy);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => _fallbackPolicyProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => _fallbackPolicyProvider.GetFallbackPolicyAsync();
}

public record SimplePolicy(string Resource, string Action);
