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
        parser = new();
    }

    [Fact]
    public void ShouldCorrectlyIdentifyNamespaceWithSemicolon()
    {
        Namespace @namespace = structureParser.Parse(justTheLineWithSemiColon);

        Assert.Equal("CodeBaseSpelunker.UnitTests.FileStructureParserTests", Namespace.Name);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyNamespaceWithBracket()
    {
        Namespace @namespace = structureParser.Parse(justTheLineWithBracket);

        Assert.Equal("CodeBaseSpelunker.UnitTests.FileStructureParserTests", Namespace.Name);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyNamespaceWithOutSemiColonOrBracket()
    {
        Namespace @namespace = structureParser.Parse(justTheLineWithOutSemiColonOrBracket);

        Assert.Equal("CodeBaseSpelunker.UnitTests.FileStructureParserTests", Namespace.Name);
    }
}
