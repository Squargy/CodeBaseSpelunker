using CodeBaseSpelunker.Core;
using CodeBaseSpelunker.Parser;
using System.Collections;

namespace CodeBaseSpelunker.UnitTests.FileStructureParserTests;

public class CommentTests
{
    StructureParser structureParser;

    public CommentTests()
    {
        structureParser = new();
    }

    [Theory]
    [ClassData(typeof(SingleLineGenerator))]
    public void ShouldCorrectlyParseSingleLineCommentsAndDocumentation(string line)
    {
        SyntaxObject ignoredSyntax = structureParser.Parse(line);

        Assert.IsType<IgnoredSyntaxObject>(ignoredSyntax);
    }

    [Theory]
    [ClassData(typeof(MultiLineStartGenerator))]
    public void ShouldCorrectlyParseMultiLineCommentsAndDocumentation(string line)
    {
        SyntaxObject ignoredSyntax = structureParser.Parse(line);

        Assert.IsType<IgnoredSyntaxObject>(ignoredSyntax);
    }

    [Theory]
    [ClassData(typeof(MultiLineStartGenerator))]
    public void ShouldCorrectlySetIgnoreLinesForMultiLineCommentsAndDocumentationStart(string line)
    {
        structureParser.Parse(line);

        Assert.True(structureParser.InsideMultiLineComment);
    }

    [Theory]
    [ClassData(typeof(MultiLineEndGenerator))]
    public void ShouldCorrectlySetIgnoreLinesForMultiLineCommentsAndDocumentationStartEnd(string line)
    {
        structureParser.InsideMultiLineComment = true;
        structureParser.Parse(line);

        Assert.False(structureParser.InsideMultiLineComment);
    }

    [Fact]
    public void ShouldCorrectlyIgnoreValidSyntaxIfParserIsIgnoring()
    {
        structureParser.InsideMultiLineComment = true;
        var syntaxObj = structureParser.Parse("public class ClassName");

        Assert.IsType<IgnoredSyntaxObject>(syntaxObj);
    }
}

internal class SingleLineGenerator : IEnumerable<object[]>
{
    const string singleLineComment = "// comment";
    const string singleLineCommentHeadWS = "  // comment";
    const string singleLineDocumentationComment = "/// comment";
    const string singleLineDocumentationCommentHeadWS = "  /// comment";

    private readonly List<object[]> _data = new List<object[]>()
        {
            new object[] { singleLineComment },
            new object[] { singleLineDocumentationComment },
            new object[] { singleLineCommentHeadWS },
            new object[] { singleLineDocumentationCommentHeadWS },
        };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal class MultiLineStartGenerator : IEnumerable<object[]>
{
    const string multiLineCommentStart = "/* comment";
    const string multiLineCommentHeadWS = "  /* comment";
    const string multiLineDocumentationCommentStart = "/** comment";
    const string multiLineDocumentationCommentHeadWS = "  /** comment";

    private readonly List<object[]> _data = new List<object[]>()
        {
            new object[] { multiLineCommentStart },
            new object[] { multiLineCommentHeadWS },
            new object[] { multiLineDocumentationCommentStart },
            new object[] { multiLineDocumentationCommentHeadWS },
        };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal class MultiLineEndGenerator : IEnumerable<object[]>
{
    const string multiLineCommentEnd = "comment */";
    const string multiLineDocumentationCommentEnd = "comment **/";

    private readonly List<object[]> _data = new List<object[]>()
        {
            new object[] { multiLineCommentEnd },
            new object[] { multiLineDocumentationCommentEnd },
        };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}