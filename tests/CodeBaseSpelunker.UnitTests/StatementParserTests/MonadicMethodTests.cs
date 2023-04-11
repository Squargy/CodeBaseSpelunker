using CodeBaseSpelunker.Core;
using CodeBaseSpelunker.Parser;

namespace CodeBaseSpelunker.UnitTests.StatementParserTests;

public class MonadicMethodTests
{
    StatementParser statementParser;

    public MonadicMethodTests()
    {
        statementParser = new();
    }

    [Fact]
    public void ShouldCorrectlyIdentifyMethodCallWithInnerMethodCalls()
    {
        const string line = "MethodName(InnerMethodName())";

        Statement statement = statementParser.Parse(line);

        Assert.Collection(statement.MethodNames,
            item => Assert.Equal("MethodName", item),
            item => Assert.Equal("InnerMethodName", item)
            );
    }

    [Fact]
    public void ShouldCorrectlyReturnMethodNameWithParameter()
    {
        const string line = "MethodName(parameter)";

        Statement statement = statementParser.Parse(line);

        Assert.Equal("MethodName", statement.MethodNames.Single());
    }
}
