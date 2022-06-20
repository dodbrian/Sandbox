using Xunit.Abstractions;

namespace OutputFromTest;

public class ConsoleWriterTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ConsoleWriterTests(ITestOutputHelper testOutputHelper) => _testOutputHelper = testOutputHelper;

    [Fact]
    public void Should_write_to_the_test_console()
    {
        // arrange
        var output = new StringWriter();
        Console.SetOut(output);

        const string expectedMessage = "This is a test line that should be visible in the test output.";

        // act
        ConsoleWriter.Write(expectedMessage);

        // assert
        var outputString = output.ToString();

        _testOutputHelper.WriteLine(outputString);

        Assert.Equal(expectedMessage + Environment.NewLine, outputString);
    }
}