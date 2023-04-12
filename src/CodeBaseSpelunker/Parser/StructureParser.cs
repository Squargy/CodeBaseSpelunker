using CodeBaseSpelunker.Core;

namespace CodeBaseSpelunker.Parser;

public class StructureParser
{
    public SyntaxObject Parse(string line)
    {
        line = line.Trim();

        if (line.StartsWith("namespace"))
        {
            Namespace ns = new Namespace();
            ns.Name = line.Substring(10).TrimEnd(';', '{');
            return ns;
        }

        if (line.Contains("class "))
        {
            Class c = new Class();
            c.Name = line.Substring(6).TrimEnd();
            return c;
        }

        return new InvalidSyntaxObject();
    }
}
