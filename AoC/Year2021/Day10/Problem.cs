namespace AoC.Year2021.Day10;

public class Problem
{
    private readonly Dictionary<char, int> _valueTable = new()
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 },
        { '#', 0 }
    };

    private static readonly Dictionary<char, char> Parentheses = new()
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' },
        { '>', '<' }
    };

    public int Part1(string input) =>
        input.Split("\n")
            .Select(GetTheFirstCorruptChar)
            .Select(c => _valueTable[c])
            .Sum();

    private static char GetTheFirstCorruptChar(string line)
    {
        var stack = new Stack<char>();
        foreach (var c in line.ToCharArray())
        {
            if (!Parentheses.ContainsKey(c))
            {
                stack.Push(c);
                continue;
            }

            var lastParentheses = stack.Pop();
            if (lastParentheses != Parentheses[c])
            {
                return c;
            }
        }

        return '#';
    }

    public int Part2(string input)
    {
        return -1;
    }
}