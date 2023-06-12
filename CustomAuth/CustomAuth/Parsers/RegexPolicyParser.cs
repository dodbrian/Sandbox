using System.Text.RegularExpressions;
using CustomAuth.Identity;

namespace CustomAuth.Parsers;

public class RegexPolicyParser
{
    private readonly Regex _regex = new(
        @"((?'Resource'[^:{};]+):)?((?'Action'[^:,;\[{}]+)(\[((?'Condition'[^,\]]+?)=(?'Value'[^\]]+?),?)+\])?,?)+(?'Children'{.+?})?(;|)",
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

    public bool TryParse(string policyName, out Policy expressionPolicy)
    {
        var matches = _regex.Matches(policyName);

        if (!matches.Any())
        {
            expressionPolicy = null;
            return false;
        }

        expressionPolicy = new Policy(
            new[]
            {
                new Permission
                {
                    Resource = matches[0].Groups["Resource"].Value,
                    Operations = new List<Operation> { new() { Name = matches[0].Groups["Action"].Value } }
                }
            });

        return true;
    }
}
