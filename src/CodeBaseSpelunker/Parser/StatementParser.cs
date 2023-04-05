using CodeBaseSpelunker.Core;

namespace CodeBaseSpelunker.Parser;

public class StatementParser
{
    public Statement Parse(string line)
    {
        var indexOfParenthesis = line.IndexOf('(');

        if (indexOfParenthesis > 0)
        {
            var methodName = string.Concat(line.Take(indexOfParenthesis)).Trim();
            return new Statement { MethodName = methodName, Type = StatementType.MethodCall };
        }
        else
            return new Statement();
    }
}
