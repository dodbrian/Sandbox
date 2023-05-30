using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.PolicyParsingEngine;

public static class TestPolicyParsing
{
    public static void Run()
    {
        var parser = new PolicyParser();

        var policy = parser.Parse(
            "Project:Read[Project=123]{WorkItem:Read,Update[Participant=42];Issue:Create};Role:Admin;Project:*[Company=345]{*};Role:PM;Project:*[Project=456]");

        Console.WriteLine(
            JsonSerializer.Serialize(
                policy,
                new JsonSerializerOptions
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                }));
    }
}
