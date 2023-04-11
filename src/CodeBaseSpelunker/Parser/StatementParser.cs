using CodeBaseSpelunker.Core;
using System.Text;

namespace CodeBaseSpelunker.Parser;

public class StatementParser
{
    public Statement Parse(string line)
    {
        List<string> methodNames = new();
        StringBuilder methodNameBuilder = new();

        foreach (var c in line)
        {
            switch (c)
            {
                case ';':
                    break;
                case '(':
                    methodNames.Add(methodNameBuilder.ToString().Trim('.', ' '));
                    methodNameBuilder.Clear();
                    break;
                case ')':
                    methodNameBuilder.Clear();
                    break;
                default:
                    methodNameBuilder.Append(c);
                    break;
            }
        }

        return new Statement { MethodNames = methodNames, Type = methodNames.Any() ? StatementType.MethodCall : StatementType.None };
    }
}
