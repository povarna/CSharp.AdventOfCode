using System.Text.RegularExpressions;

namespace AoC.Year2015.Day08;

public class Problem
{
    public int Part1(string input) =>
        input.Split("\n")
            .Where(line => line.Length > 2)
            .Select(line => new
            {
                charCount = line.Length,
                inMemoryCount = Regex.Unescape(line.Substring(1, line.Length - 2)).Length
            })
            .Select(t => t.charCount - t.inMemoryCount)
            .Sum();

    public int Part2(string input) =>
        input.Split("\n")
            .Select(line => new
            {
                lineLenght = line.Length,
                newLineLenght = ("\"" +
                                 line
                                     .Replace("\\", "\\\\")
                                     .Replace("\"", "\\\"")
                                 + "\"")
                    .Length
            })
            .Select(l => l.newLineLenght - l.lineLenght)
            .Sum();
}