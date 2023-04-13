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

    private void AssertClass(SyntaxObject obj, string expectedName, string expectedAccessModifier)
    {
        Assert.NotNull(obj);
        Assert.IsType<Class>(obj);
        Assert.Equal(expectedName, obj.Name);
        Assert.Equal(expectedAccessModifier, (obj as Class)!.AccessModifier);
    }

    [Fact]
    public void ShouldCorrectlyIdentifyClassWithoutKeyword()
    {
        SyntaxObject @class = structureParser.Parse(classWithoutKeywordLine);
        AssertClass(@class, "ClassName", "private");
    }

    [Fact]
    public void ShouldCorrectlyIdentifyClassAndPublic()
    {
        SyntaxObject @class = structureParser.Parse(classWithoutWithPublicAccessModifier);
        AssertClass(@class, "ClassName", "public");
    }

    [Fact]
    public void ShouldCorrectlyIdentifyClassAndInternal()
    {
        SyntaxObject @class = structureParser.Parse(classWithoutWithInternalAccessModifier);
        AssertClass(@class, "ClassName", "internal");
    }

    [Fact]
    public void ShouldCorrectlyIdentifyClassAndProtected()
    {
        SyntaxObject @class = structureParser.Parse(classWithoutWithProtectedAccessModifier);
        AssertClass(@class, "ClassName", "protected");
    }

    [Fact]
    public void ShouldCorrectlyIdentifyClassAndPrivate()
    {
        SyntaxObject @class = structureParser.Parse(classWithoutWithPrivateAccessModifier);
        AssertClass(@class, "ClassName", "private");
    }

    [Fact]
    public void ShouldCorrectlyAddClassToNamespace()
    {
        Namespace @namespace = new Namespace();
        @namespace.Name = "foo";

        structureParser.CurrentNamespace = @namespace;

        SyntaxObject syntaxObj = structureParser.Parse(classWithoutKeywordLine);

        AssertClass(syntaxObj, "ClassName", "private");

        var @class = (syntaxObj as Class);

        Assert.Equal("foo", @class!.Namespace.Name);
    }

}
