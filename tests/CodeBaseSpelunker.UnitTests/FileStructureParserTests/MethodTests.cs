using CodeBaseSpelunker.Core;
using CodeBaseSpelunker.Parser;

namespace CodeBaseSpelunker.UnitTests.FileStructureParserTests;

public class MethodTests
{
    StructureParser structureParser;

    const string lineWithMethod = "void MethodName()";
    const string lineWithMethodWithReturnType = "ReturnTypeName MethodName()";

    public MethodTests()
    {
        structureParser = new();
        structureParser.CurrentClass = new Class() { Name = "ClassName", Namespace = new Namespace { Name = "NamespaceName"} };
    }

    [Fact]
    public void ShouldSetMethodName()
    {
        SyntaxObject method = structureParser.Parse(lineWithMethod);

        Assert.IsType<Method>(method);
        Assert.Equal("MethodName", method.Name);
    }

    [Fact]
    public void ShouldSetMethodReturnTypeVoid()
    {
        SyntaxObject method = structureParser.Parse(lineWithMethod);

        Assert.IsType<Method>(method);
        Assert.Equal("void", (method as Method).ReturnType);
    }

    [Fact]
    public void ShouldSetMethodReturnTypeName()
    {
        SyntaxObject method = structureParser.Parse(lineWithMethodWithReturnType);

        Assert.IsType<Method>(method);
        Assert.Equal("ReturnTypeName", (method as Method).ReturnType);
    }

    [Fact]
    public void ShouldSetClassToMethod()
    {
        structureParser.CurrentClass = new Class { Name = "ClassName" };
        SyntaxObject method = structureParser.Parse(lineWithMethod);

        Assert.IsType<Method>(method);
        Assert.Equal(structureParser.CurrentClass, (method as Method).Class);
    }

    [Fact]
    public void ShouldSetMethodToClass()
    {
        structureParser.CurrentClass = new Class { Name = "ClassName" };
        SyntaxObject method = structureParser.Parse(lineWithMethod);

        Assert.IsType<Method>(method);
        Assert.Collection(structureParser.CurrentClass.Methods,
                item => Assert.Equal<Method>((Method)method, item)
            );
    }
}
