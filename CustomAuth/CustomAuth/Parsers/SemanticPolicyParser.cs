using CustomAuth.Identity;
using Parlot;
using Parlot.Fluent;
using static Parlot.Fluent.Parsers;

namespace CustomAuth.Parsers;

public class SemanticPolicyParser
{
    private static readonly TextSpan AsteriskSpan = new("*");
    private static readonly Parser<TextSpan> Asterisk = Terms.Char('*').Then(static _ => AsteriskSpan);
    private static readonly Parser<TextSpan> Identifier = Terms.Identifier();
    private static readonly Parser<char> EqualsSign = Terms.Char('=');
    private static readonly Parser<char> OpenBrace = Terms.Char('[');
    private static readonly Parser<char> CloseBrace = Terms.Char(']');
    private static readonly Parser<char> OpenCurly = Terms.Char('{');
    private static readonly Parser<char> CloseCurly = Terms.Char('}');
    private static readonly Parser<char> Colon = Terms.Char(':');
    private static readonly Parser<char> SemiColon = Terms.Char(';');
    private static readonly Parser<char> Comma = Terms.Char(',');

    private static readonly Parser<TextSpan> Value =
        Identifier.Or(Terms.Integer().Then(num => new TextSpan(num.ToString())));

    public bool TryParse(string policyString, out Policy policy)
    {
        policy = ParsePolicy(policyString);

        return policy.Permissions.Any();
    }

    public static Policy ParsePolicy(string policyString)
    {
        var context = new ParseContext(new Scanner(policyString));
        var parser = CreatePolicyParser();

        var permissions = parser.Parse(context) ?? Enumerable.Empty<Permission>();
        var policy = new Policy(permissions);

        return policy;
    }

    private static Parser<List<Permission>> CreatePolicyParser()
    {
        // Condition=Value
        var condition = Identifier
            .AndSkip(EqualsSign)
            .And(Value)
            .Then(static condition => new Condition(condition.Item1.ToString(), condition.Item2.ToString()));

        // [Condition=Value,Condition=Value]
        var conditions = ZeroOrOne(
            Between(OpenBrace, Separated(Comma, condition), CloseBrace));

        // Operation[Condition=Value,Condition=Value]
        var operation = Identifier
            .Or(Asterisk)
            .And(ZeroOrOne(conditions));

        // Operation[Condition=Value,Condition=Value],Operation
        var operations = Separated(Comma, operation);

        // Resource:
        var resource = ZeroOrOne(Identifier.Or(Asterisk).AndSkip(Colon));

        // Recursive parser for nested permissions
        var deferredPermission = Deferred<Permission>();

        // Permission;Permission
        var permissions = Separated(SemiColon, deferredPermission);

        // {Permission;Permission}
        var nestedPermissions = ZeroOrOne(Between(OpenCurly, permissions, CloseCurly));

        // Resource:Operation[Condition=Value,Condition=Value],Operation{...here goes a list of child permissions
        // separated by a semicolon...};...
        var permissionWithNested = resource
            .And(operations)
            .And(nestedPermissions);

        deferredPermission.Parser = permissionWithNested.Then(
            static fullPermission =>
            {
                var (resource, operations, nested) = fullPermission;
                return new Permission
                {
                    Resource = resource.ToString() ?? "*",
                    Operations = operations.Select(
                            static operation => new Operation
                            {
                                Name = operation.Item1.ToString(),
                                Conditions = operation.Item2
                            })
                        .ToList(),
                    Children = nested
                };
            });

        return permissions;
    }
}
