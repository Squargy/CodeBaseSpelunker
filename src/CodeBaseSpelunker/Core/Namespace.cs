namespace CodeBaseSpelunker.Core;

public class Namespace : SyntaxObject
{
    public static Namespace Global = new Namespace() { Name = "global" };
    public List<Class> Classes { get; init; } = new List<Class>();
}
