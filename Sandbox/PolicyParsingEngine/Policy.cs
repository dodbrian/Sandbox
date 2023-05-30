using System.Collections.Generic;

namespace Sandbox.PolicyParsingEngine;

public class Policy
{
    public List<Permission> Permissions { get; set; }
}

public class Permission
{
    public string Resource { get; set; }
    public List<string> Actions { get; set; }
    public Dictionary<string, string> Conditions { get; set; }
    public List<Permission> NestedPermissions { get; set; }
}
