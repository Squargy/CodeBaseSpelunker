using CodeBaseSpelunker.Core;
using System.Text.RegularExpressions;

namespace CodeBaseSpelunker.Parser;

public class StructureParser
{
    public Namespace CurrentNamespace { get; set; } = Namespace.Global;
    public bool InsideMultiLineComment { get; set; } = false;

    public SyntaxObject Parse(string line)
    {
        Regex space = new Regex("\\s+");
        line = line.Trim();

        if (line.Contains("*/"))
        {
            InsideMultiLineComment = false;
            return new IgnoredSyntaxObject("Multiline comment end");
        }

        if (InsideMultiLineComment)
        {
            return new IgnoredSyntaxObject("Inside comment");
        }

        if (line.StartsWith("/*"))
        {
            InsideMultiLineComment = true;
            return new IgnoredSyntaxObject("Multiline comment start");
        }

        if (line.StartsWith("//"))
            return new IgnoredSyntaxObject("Single line Comment");

        if (line.StartsWith("namespace"))
        {
            Namespace ns = new Namespace();
            ns.Name = line.Substring(10).TrimEnd(';', '{');
            return ns;
        }

        if (line.Contains("class "))
        {
            var parts = space.Split(line);

            Class c = new Class();
            c.Name = parts.Last();

            string ac = parts.First();
            switch (ac)
            {
                case "class":
                    c.AccessModifier = "private";
                    break;
                default:
                    c.AccessModifier = ac;
                    break;
            };

            CurrentNamespace.Classes.Add(c);
            c.Namespace = CurrentNamespace;

            return c;
        }

        return new IgnoredSyntaxObject();
    }
}
