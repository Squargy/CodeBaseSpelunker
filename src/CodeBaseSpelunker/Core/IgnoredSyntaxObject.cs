namespace CodeBaseSpelunker.Core;

public class IgnoredSyntaxObject : SyntaxObject
{
	const string INVALID_SYNTAX_OBJECT = "IGNORED SYNTAX";

    public IgnoredSyntaxObject()
	{
		Name = INVALID_SYNTAX_OBJECT;
    }

    public IgnoredSyntaxObject(string name)
    {
        Name = name;
    }
}
