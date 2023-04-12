using CodeBaseSpelunker.Core;
using CodeBaseSpelunker.Parser;
using System.Security.Claims;

namespace CodeBaseSpelunker.UnitTests.FileStructureParserTests;

public class ClassTests
{
    const string classWithoutKeywordLine = "class ClassName";
    const string classWithoutWithPublicAccessModifier = "public class ClassName";
    const string classWithoutWithInternalAccessModifier = "internal class ClassName";
    const string classWithoutWithProtectedAccessModifier = "protected class ClassName";
    const string classWithoutWithPrivateAccessModifier = "private class ClassName";

    StructureParser structureParser;

    public ClassTests()
    {
        structureParser = new();
    }

    [Fact]
    public void ShouldCorrectlyIdentifyClassWithoutKeyword()
    {
        SyntaxObject @class = structureParser.Parse(classWithoutKeywordLine);

        Assert.IsType<Class>(@class);
        Assert.Equal("private", @class.AccessModifier);
        Assert.Equal("ClassName", @class.Name);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyClassAndPublic()
    {
        SyntaxObject @class = structureParser.Parse(classWithoutWithPublicAccessModifier);

        Assert.IsType<Class>(@class);
        Assert.Equal("public", @class.AccessModifier);
        Assert.Equal("ClassName", @class.Name);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyClassAndInternal()
    {
        SyntaxObject @class = structureParser.Parse(classWithoutWithInternalAccessModifier);

        Assert.IsType<Class>(@class);
        Assert.Equal("internal", @class.AccessModifier);
        Assert.Equal("ClassName", @class.Name);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyClassAndProtected()
    {
        SyntaxObject @class = structureParser.Parse(classWithoutWithProtectedAccessModifier);

        Assert.IsType<Class>(@class);
        Assert.Equal("protected", @class.AccessModifier);
        Assert.Equal("ClassName", @class.Name);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyClassAndPrivate()
    {
        SyntaxObject @class = structureParser.Parse(classWithoutWithPrivateAccessModifier);

        Assert.IsType<Class>(@class);
        Assert.Equal("private", @class.AccessModifier);
        Assert.Equal("ClassName", @class.Name);
    }
}
