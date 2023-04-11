using CodeBaseSpelunker.Core;
using CodeBaseSpelunker.Parser;

namespace CodeBaseSpelunker.UnitTests.StatementParserTests;

public class NiladicMethodTests
{
    StatementParser statementParser;

    public NiladicMethodTests()
    {
        statementParser = new();
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

        Assert.Equal(expectedName, statement.MethodNames.Single());
    }

    [Fact]
    public void ShouldCorrectlyIdentifyTwoChainedMethodCalls()
    {
        const string line = "MethodName().FollowingName()";

        Statement statement = statementParser.Parse(line);

        Assert.Collection(statement.MethodNames,
            item => Assert.Equal("MethodName", item),
            item => Assert.Equal("FollowingName", item)
            );
    }

    [Fact]
    public void ShouldCorrectlyIdentifyThreeChainedMethodCalls()
    {
        const string line = "MethodName().FollowingName().FinalName()";

        Statement statement = statementParser.Parse(line);

        Assert.Collection(statement.MethodNames,
            item => Assert.Equal("MethodName", item),
            item => Assert.Equal("FollowingName", item),
            item => Assert.Equal("FinalName", item)
            );
    }
}
