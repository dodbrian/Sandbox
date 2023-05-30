using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.PolicyParsingEngine;

public class PolicyParser
{
    private string _input;
    private int _pos;

    public Policy Parse(string policyString)
    {
        _input = policyString;
        _pos = 0;

        var policy = new Policy
        {
            Permissions = ParsePermissions()
        };

        return policy;
    }

    private List<Permission> ParsePermissions()
    {
        var permissions = new List<Permission>();

        do
        {
            if (Peek() == ';') Expect(';');

            var permission = ParsePermission();
            permissions.Add(permission);
        } while (Peek() == ';');

        return permissions;
    }

    private Permission ParsePermission()
    {
        var permission = new Permission();

        // Parse resource
        permission.Resource = ParseResource();

        if (Peek() == '}' && permission.Resource == "*") return permission;

        Expect(':');

        // Parse actions
        permission.Actions = ParseActions();

        // Parse conditions (if they exist)
        if (Peek() == '[') permission.Conditions = ParseConditions();

        // Parse nested policies (if they exist)
        if (Peek() == '{') permission.NestedPermissions = ParseNestedPermissions();

        return permission;
    }

    private string ParseResource() => ParseUntil(':', '}');

    private List<string> ParseActions() => ParseUntil('[', '{', '}', ';').Split(',').ToList();

    private Dictionary<string, string> ParseConditions()
    {
        Expect('[');
        var conditions = ParseUntil(']')
            .Split(',')
            .Select(part => part.Split('='))
            .ToDictionary(pair => pair[0], pair => pair[1]);

        Expect(']');
        return conditions;
    }

    private List<Permission> ParseNestedPermissions()
    {
        Expect('{');
        var permissions = new List<Permission>();

        while (Peek() != '}')
        {
            permissions.Add(ParsePermission());
            if (Peek() == ';') Expect(';');
        }

        Expect('}');

        return permissions;
    }

    private char Peek() => _pos < _input.Length ? _input[_pos] : '\0';

    private void Expect(char expected)
    {
        if (Peek() != expected) throw new FormatException($"Expected '{expected}' at position {_pos}.");

        _pos++;
    }

    private string ParseUntil(params char[] chars)
    {
        var start = _pos;

        while (_pos < _input.Length && !chars.Contains(_input[_pos])) _pos++;

        return _input.Substring(start, _pos - start);
    }
}
