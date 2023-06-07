using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace CustomAuth.Identity;

public class ExpressionPolicyProvider : IAuthorizationPolicyProvider
{
    private readonly ExpressionPolicyParser _expressionPolicyParser;
    private readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider;

    public ExpressionPolicyProvider(
        IOptions<AuthorizationOptions> options,
        ExpressionPolicyParser expressionPolicyParser)
    {
        _expressionPolicyParser = expressionPolicyParser;
        _fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
    }

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (!_expressionPolicyParser.TryParse(policyName, out var expressionPolicy))
            return _fallbackPolicyProvider.GetPolicyAsync(policyName);

        var authorizationPolicy = new AuthorizationPolicyBuilder()
            .AddRequirements(new AuthRequirement(expressionPolicy))
            .Build();

        return Task.FromResult<AuthorizationPolicy?>(authorizationPolicy);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => _fallbackPolicyProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => _fallbackPolicyProvider.GetFallbackPolicyAsync();
}

public class ExpressionPolicyParser
{
    private readonly Regex _regex = new(
        @"^((?'Resource'[A-Za-z0-9]+|\*):(?'Action'([A-Za-z0-9]+|\*)(\[((?'Condition'[A-Za-z0-9]+)=(?'Value'[A-Za-z0-9$]+),?)+\])?,?)+({(?'Children'.+?)})?|(?'Resource'\*)(\[((?'Condition'[A-Za-z0-9]+)=(?'Value'[A-Za-z0-9$]+),?)+\])?);?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

    public bool TryParse(string policyName, out SimplePolicy expressionPolicy)
    {
        var matches = _regex.Matches(policyName);

        if (!matches.Any())
        {
            expressionPolicy = null;
            return false;
        }

        expressionPolicy = new SimplePolicy(
            Resource: matches[0].Groups["Resource"].Value,
            Action: matches[0].Groups["Action"].Value);

        return true;
    }
}

public record SimplePolicy(string Resource, string Action);
