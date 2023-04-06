using CodeBaseSpelunker.Core;
using CodeBaseSpelunker.Parser;

namespace CodeBaseSpelunker.UnitTests.StatementParserTests;

public class NonMethodTests
{
    StatementParser statementParser;

    public NonMethodTests()
    {
        statementParser = new();
    }

    [Fact]
    public void ShouldCorrectlyIdentifyNonMethodCall()
    {
        const string line = "int counter;";

        Statement statement = statementParser.Parse(line);

        Assert.Equal(StatementType.None, statement.Type);
    }
}
