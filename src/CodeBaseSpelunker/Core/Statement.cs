namespace CodeBaseSpelunker.Core;

public class Statement
{
    public StatementType Type { get; init; }
    public List<string> MethodNames { get; init; } = new();
}
