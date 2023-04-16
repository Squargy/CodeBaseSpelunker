namespace CodeBaseSpelunker.Core;

public class Class : SyntaxObject
{
    public Namespace Namespace { get; set; }
    public string AccessModifier { get; set; }
    public IList<Method> Methods { get; set; } = new List<Method>();
}
