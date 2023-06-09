using System.Text.RegularExpressions;
using CustomAuth.Identity;

namespace CustomAuth.Parsers;

public class RegexPolicyParser
{
    private readonly Regex _regex = new(
        @"((?'Resource'[^:{};]+):)?((?'Action'[^:,;\[{}]+)(\[((?'Condition'[^,\]]+?)=(?'Value'[^\]]+?),?)+\])?,?)+(?'Children'{.+?})?(;|)",
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
