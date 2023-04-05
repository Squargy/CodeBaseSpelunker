using CodeBaseSpelunker.Core;
using CodeBaseSpelunker.Parser;

namespace CodeBaseSpelunker.UnitTests;

public class StatementParserTests
{
    StatementParser statementParser;

    public StatementParserTests()
    {
        statementParser = new();
    }

    [Fact]
    public void ShouldCorrectlyIdentifyMethodCall()
    {
        const string line = "MethodCall()";

        Statement statement = statementParser.Parse(line);

        Assert.Equal(StatementType.MethodCall, statement.Type);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyNonMethodCall()
    {
        const string line = "int counter;";

        Statement statement = statementParser.Parse(line);

        Assert.Equal(StatementType.None, statement.Type);
    }

    [Theory]
    [InlineData("MethodName()", "MethodName")]
    [InlineData("MethodName2()", "MethodName2")]
    [InlineData("     MethodName()", "MethodName")]
    [InlineData("MethodName  ()", "MethodName")]
    [InlineData("MethodName()    ", "MethodName")]
    [InlineData("MethodName(    )", "MethodName")]
    public void ShouldCorrectlyReturnMethodName(string line, string expectedName)
    {
        Statement statement = statementParser.Parse(line);

        Assert.Equal(expectedName, statement.MethodName);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyMultipleMethodCalls()
    {
        const string line = "MethodCall().FollowingCall()";

        Statement statement = statementParser.Parse(line);

        Assert.Collection(statement.MethodNames,
            item => Assert.Equal("MethodCall", item),
            item => Assert.Equal("FollowingCall", item)
            );
    }
}
