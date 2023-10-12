using System.Text;

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

    private static readonly Dictionary<char, int> Scores = new()
    {
        { ')', 1 },
        { ']', 2 },
        { '}', 3 },
        { '>', 4 },
    };

    private static readonly Dictionary<char, char> Parentheses = new()
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' },
        { '>', '<' }
    };

    private static readonly Dictionary<char, char> ReverseParentheses = new()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
        { '<', '>' }
    };

    public int Part1(string input) =>
        input.Split("\n")
            .Select(line => line.Trim())
            .Select(GetTheFirstCorruptChar)
            .Select(c => _valueTable[c])
            .Sum();

    public long Part2(string input)
    {
        var scores = input.Split("\n")
            .Select(line => line.Trim())
            .Select(GetCompleteString)
            .Select(CalculateScore)
            .Where(s => s > 0)
            .ToArray();
        
        Array.Sort(scores);
        return scores[scores.Length / 2];
    }

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

    private static string GetCompleteString(string line)
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
                return string.Empty;
            }
        }

        var str = new StringBuilder();
        while (stack.Any())
        {
            var parentheses = stack.Pop();
            str.Append(ReverseParentheses[parentheses]);
        }

        return str.ToString();
    }

    private static long CalculateScore(string str) =>
        str.ToCharArray().Aggregate(0L, (current, c) => current * 5 + Scores[c]);
}