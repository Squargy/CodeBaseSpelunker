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
    public void ShouldCorrectlyReturnMethodNameWithParameter()
    {
        const string line = "MethodName()";

        Statement statement = statementParser.Parse(line);

        Assert.Equal("MethodName", statement.MethodNames.Single());
    }
}
