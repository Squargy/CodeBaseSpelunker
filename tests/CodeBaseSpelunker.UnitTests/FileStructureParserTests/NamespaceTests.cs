using CodeBaseSpelunker.Core;
using CodeBaseSpelunker.Parser;

namespace CodeBaseSpelunker.UnitTests.FileStructureParserTests;

public class NamespaceTests
{
    const string justTheLineWithSemiColon = "namespace CodeBaseSpelunker.UnitTests.FileStructureParserTests;";
    const string justTheLineWithBracket = "namespace CodeBaseSpelunker.UnitTests.FileStructureParserTests{";
    const string justTheLineWithOutSemiColonOrBracket = "namespace CodeBaseSpelunker.UnitTests.FileStructureParserTests";

    StructureParser structureParser;

    public NamespaceTests()
    {
        structureParser = new();
    }

    [Fact]
    public void ShouldCorrectlyIdentifyNamespaceWithSemicolon()
    {
        SyntaxObject @namespace = structureParser.Parse(justTheLineWithSemiColon);

        Assert.IsType<Namespace>(@namespace);
        Assert.Equal("CodeBaseSpelunker.UnitTests.FileStructureParserTests", @namespace.Name);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyNamespaceWithBracket()
    {
        SyntaxObject @namespace = structureParser.Parse(justTheLineWithBracket);

        Assert.IsType<Namespace>(@namespace);
        Assert.Equal("CodeBaseSpelunker.UnitTests.FileStructureParserTests", @namespace.Name);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyNamespaceWithOutSemiColonOrBracket()
    {
        SyntaxObject @namespace = structureParser.Parse(justTheLineWithOutSemiColonOrBracket);

        Assert.IsType<Namespace>(@namespace);
        Assert.Equal("CodeBaseSpelunker.UnitTests.FileStructureParserTests", @namespace.Name);
    }
}
