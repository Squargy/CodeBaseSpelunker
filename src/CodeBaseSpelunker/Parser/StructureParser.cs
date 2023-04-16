using CodeBaseSpelunker.Core;
using System.Text.RegularExpressions;

namespace CodeBaseSpelunker.Parser;

public class StructureParser
{
    public Namespace CurrentNamespace { get; set; } = Namespace.Global;
    public bool InsideMultiLineComment { get; set; } = false;
    public Class CurrentClass { get; set; }

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

        var startParam = line.IndexOf("(");
        var endParam = line.IndexOf(")");
        if (startParam < endParam)
        {
            var parts = line.Substring(0, startParam).Split(" ");

            Method method = new Method();
            method.Name = parts.Last();
            method.ReturnType = parts.First();
            method.Class = CurrentClass;
            CurrentClass.Methods.Add(method);

            return method;
        }

        return new IgnoredSyntaxObject();
    }
}
