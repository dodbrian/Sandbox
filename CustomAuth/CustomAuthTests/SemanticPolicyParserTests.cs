using CustomAuth.Parsers;
using FluentAssertions;

namespace CustomAuthTests;

public class SemanticPolicyParserTests
{
    [Fact]
    public void Test1()
    {
        // arrange
        const string policy =
            "Project:Read[Project=$project,Company=$company],Create{WorkItem:Read,Update[Participant=$participant]};" +
            "Task:Delete;" +
            "Task:*;" +
            "*:*;" +
            "*;" +
            "*:Delete;" +
            "*:*[Test=333];" +
            "*[Test=123];" +
            "Label:Create{Color:Update;Font:Scale{Ligatures:Enable[User=$user]}};" +
            "Template:Read{*}";

        // act
        var permissions = SemanticPolicyParser.ParsePolicy(policy);

        // assert
        permissions.Should().NotBeNull();
    }

    [Fact]
    public void ParsePolicy_ShouldParseSimplePolicy()
    {
        const string text =
            "Project:Read[Project=$project,Company=$company],Create{WorkItem:Read,Update[Participant=$participant]};";

        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("Project");
        permission.Operations.Should().HaveCount(2);

        var readOperation = permission.Operations[0];
        readOperation.Name.Should().Be("Read");
        readOperation.Conditions.Should().HaveCount(2);
        readOperation.Conditions[0].Name.Should().Be("Project");
        readOperation.Conditions[0].Value.Should().Be("$project");
        readOperation.Conditions[1].Name.Should().Be("Company");
        readOperation.Conditions[1].Value.Should().Be("$company");

        var createOperation = permission.Operations[1];
        createOperation.Name.Should().Be("Create");
        createOperation.Conditions.Should().BeNullOrEmpty();
        permission.Children.Should().HaveCount(2);

        var workItemPermission = permission.Children[0];
        workItemPermission.Resource.Should().Be("WorkItem");
        workItemPermission.Operations.Should().HaveCount(1);
        workItemPermission.Operations[0].Name.Should().Be("Read");
        workItemPermission.Operations[0].Conditions.Should().HaveCount(0);

        var updateOperation = workItemPermission.Operations[0];
        updateOperation.Name.Should().Be("Update");
        updateOperation.Conditions.Should().HaveCount(1);
        updateOperation.Conditions[0].Name.Should().Be("Participant");
        updateOperation.Conditions[0].Value.Should().Be("$participant");
    }

    [Fact]
    public void ParsePolicy_ShouldParsePolicyWithSingleOperation()
    {
        // Arrange
        const string text = "Task:Delete;";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("Task");
        permission.Operations.Should().HaveCount(1);
        permission.Operations.First().Name.Should().Be("Delete");
        permission.Operations.First().Conditions.Should().BeNullOrEmpty();
    }

    [Fact]
    public void ParsePolicy_ShouldParsePolicyWithWildcardOperation()
    {
        // Arrange
        const string text = "Task:*;";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("Task");
        permission.Operations.Should().HaveCount(1);
        permission.Operations.First().Name.Should().Be("*");
        permission.Operations.First().Conditions.Should().BeNullOrEmpty();
    }

    [Fact]
    public void ParsePolicy_ShouldParsePolicyWithWildcardResourceAndOperation()
    {
        // Arrange
        const string text = "*:*;";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("*");
        permission.Operations.Should().HaveCount(1);
        permission.Operations.First().Name.Should().Be("*");
        permission.Operations.First().Conditions.Should().BeNullOrEmpty();
    }

    [Fact]
    public void ParsePolicy_ShouldParsePolicyWithWildcardResource()
    {
        // Arrange
        const string text = "*;";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("*");
        permission.Operations.Should().HaveCount(0);
    }

    [Fact]
    public void ParsePolicy_ShouldParsePolicyWithWildcardResourceAndSpecificOperation()
    {
        // Arrange
        const string text = "*:Delete;";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("*");
        permission.Operations.Should().HaveCount(1);
        permission.Operations.First().Name.Should().Be("Delete");
        permission.Operations.First().Conditions.Should().BeNullOrEmpty();
    }

    [Fact]
    public void ParsePolicy_ShouldParsePolicyWithWildcardResourceAndOperationAndCondition()
    {
        // Arrange
        const string text = "*:*[Test=333];";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("*");
        permission.Operations.Should().HaveCount(1);
        permission.Operations.First().Name.Should().Be("*");
        permission.Operations.First().Conditions.Should().HaveCount(1);
        permission.Operations.First().Conditions.First().Name.Should().Be("Test");
        permission.Operations.First().Conditions.First().Value.Should().Be("333");
    }

    [Fact]
    public void ParsePolicy_ShouldParsePolicyWithWildcardResourceAndCondition()
    {
        // Arrange
        const string text = "*[Test=123];";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("*");
        permission.Operations.Should().HaveCount(1);
        var operation = permission.Operations[0];
        operation.Conditions.Should().HaveCount(1);
        operation.Conditions.First().Name.Should().Be("Test");
        operation.Conditions.First().Value.Should().Be("123");
    }

    [Fact]
    public void ParsePolicy_ShouldParseNestedPolicy()
    {
        // Arrange
        const string text = "Label:Create{Color:Update;Font:Scale{Ligatures:Enable[User=$user]}};";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("Label");
        permission.Operations.Should().HaveCount(1);
        var createOperation = permission.Operations.First();
        createOperation.Name.Should().Be("Create");
        permission.Children.Should().HaveCount(2);

        var colorPermission = permission.Children[0];
        colorPermission.Resource.Should().Be("Color");
        colorPermission.Operations.Should().HaveCount(1);
        colorPermission.Operations.First().Name.Should().Be("Update");

        var fontPermission = permission.Children[1];
        fontPermission.Resource.Should().Be("Font");
        fontPermission.Operations.Should().HaveCount(1);
        var scaleOperation = fontPermission.Operations.First();
        scaleOperation.Name.Should().Be("Scale");

        var ligaturesPermission = fontPermission.Children[0];
        ligaturesPermission.Resource.Should().Be("Ligatures");
        ligaturesPermission.Operations.Should().HaveCount(1);
        var enableOperation = ligaturesPermission.Operations.First();
        enableOperation.Name.Should().Be("Enable");
        enableOperation.Conditions.Should().HaveCount(1);
        enableOperation.Conditions.First().Name.Should().Be("User");
        enableOperation.Conditions.First().Value.Should().Be("$user");
    }

    [Fact]
    public void ParsePolicy_ShouldParsePolicyWithWildcardResourceInNestedPermission()
    {
        // Arrange
        const string text = "Template:Read{*}";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("Template");
        permission.Operations.Should().HaveCount(1);
        var readOperation = permission.Operations.First();
        readOperation.Name.Should().Be("Read");
        permission.Children.Should().HaveCount(1);

        var wildcardPermission = permission.Children[0];
        wildcardPermission.Resource.Should().Be("*");
    }

    [Fact]
    public void ParsePolicy_ShouldHandleEmptyInput()
    {
        // Arrange
        const string text = "";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().BeEmpty();
    }

    [Fact]
    public void ParsePolicy_ShouldHandleWhitespaceInput()
    {
        // Arrange
        const string text = "     ";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().BeEmpty();
    }

    [Fact]
    public void ParsePolicy_ShouldIgnoreTrailingSemicolon()
    {
        // Arrange
        const string text = "Task:Delete;";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(1);
        var permission = permissions.First();

        permission.Resource.Should().Be("Task");
        permission.Operations.Should().HaveCount(1);
        permission.Operations.First().Name.Should().Be("Delete");
        permission.Operations.First().Conditions.Should().BeNullOrEmpty();
    }

    [Fact]
    public void ParsePolicy_ShouldHandleMultiplePermissions()
    {
        // Arrange
        const string text = "Task:Delete;Task:Create;Task:Update;";

        // Act
        var permissions = SemanticPolicyParser.ParsePolicy(text).Permissions;

        // Assert
        permissions.Should().HaveCount(3);
        permissions.Select(p => p.Resource).Should().AllBeEquivalentTo("Task");
        permissions.Select(p => p.Operations.First().Name).Should().Contain(new[] { "Delete", "Create", "Update" });
    }

    [Fact]
    public void ParsePolicy_ShouldThrowExceptionOnInvalidInput()
    {
        // Arrange
        const string text = "InvalidPolicy";

        // Act
        Action act = () => SemanticPolicyParser.ParsePolicy(text);

        // Assert
        act.Should().Throw<Exception>();
    }
}
