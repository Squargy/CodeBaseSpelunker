using CodeBaseSpelunker.Core;
using System.Text;

namespace CodeBaseSpelunker.Parser;

public class StatementParser
{
    public Statement Parse(string line)
    {
        List<string> methodNames = new();

        var indexOfOpeningParenthesis = line.IndexOf('(');

        if (indexOfOpeningParenthesis == -1)
           return new Statement();

        var indexOfClosingParenthesis = line.IndexOf(')');

        if (indexOfClosingParenthesis == -1)
            return new Statement();

        var methodName1 = line.Substring(0, indexOfOpeningParenthesis).Trim();
        methodNames.Add(methodName1);

        var restLine = line.Substring(indexOfClosingParenthesis + 1).Trim('.');

        indexOfOpeningParenthesis = restLine.IndexOf('(');

        if (indexOfOpeningParenthesis == -1)
            return new Statement { MethodNames = methodNames, Type = StatementType.MethodCall };

        indexOfClosingParenthesis = restLine.IndexOf(')');

        if (indexOfClosingParenthesis == -1)
            return new Statement { MethodNames = methodNames, Type = StatementType.MethodCall };

        var methodName2 = restLine.Substring(0, indexOfOpeningParenthesis).Trim();
        methodNames.Add(methodName2);

        return new Statement { MethodNames = methodNames, Type = StatementType.MethodCall };
    }

    public Statement ParseWIP(string line)
    {
        Statement statement = new();
        StringBuilder methodNameBuilder = new();
        List<string> methodNames = new();
        bool insideParams = false;

        foreach (var c in line)
        {
            switch (c)
            {
                case ';':
                    break;

                default:
                    break;
            }

            if (c == ';')
                return statement;

            if (c == ')')
                insideParams = false;

            if (c == '(' && methodNameBuilder.Length != 0)
            {
                var methodName = methodNameBuilder.ToString();
                methodNames.Add(methodName);
                methodNameBuilder.Clear();
                insideParams = true;
            }


        }

        var indexOfOpeningParenthesis = line.IndexOf('(');

        if (indexOfOpeningParenthesis == -1)
            return new Statement();

        var indexOfClosingParenthesis = line.IndexOf(')');

        if (indexOfClosingParenthesis == -1)
            return new Statement();

        var methodName1 = line.Substring(0, indexOfOpeningParenthesis).Trim();
        methodNames.Add(methodName1);

        var restLine = line.Substring(indexOfClosingParenthesis + 1).Trim('.');

        indexOfOpeningParenthesis = restLine.IndexOf('(');

        if (indexOfOpeningParenthesis == -1)
            return new Statement { MethodNames = methodNames, Type = StatementType.MethodCall };

        indexOfClosingParenthesis = restLine.IndexOf(')');

        if (indexOfClosingParenthesis == -1)
            return new Statement { MethodNames = methodNames, Type = StatementType.MethodCall };

        var methodName2 = restLine.Substring(0, indexOfOpeningParenthesis).Trim();
        methodNames.Add(methodName2);

        return new Statement { MethodNames = methodNames, Type = StatementType.MethodCall };
    }
}
