using System.Text.RegularExpressions;

namespace Year2015.Day16;

public class Problem
{
    private Dictionary<string, int> target = new()
    {
        ["children"] = 3,
        ["cats"] = 7,
        ["samoyeds"] = 2,
        ["pomeranians"] = 3,
        ["akitas"] = 0,
        ["vizslas"] = 0,
        ["goldfish"] = 5,
        ["trees"] = 3,
        ["cars"] = 2,
        ["perfumes"] = 1
    };

    public int Part1(string input)
    {
        var index = Parse(input)
            .FindIndex(dict =>
                dict.Keys.All(key =>
                    dict[key] == target[key])
            );
        return index + 1;
    }

    public int Part2(string input)
    {
        var index = Parse(input)
            .FindIndex(dict => dict.Keys.All(key =>
            {
                return key switch
                {
                    "cats" or "trees" => dict[key] > target[key],
                    "pomeranians" or "goldfish" => dict[key] < target[key],
                    _ => dict[key] == target[key]
                };
            }));
        return index + 1;
    }

    private static List<Dictionary<string, int>> Parse(string input)
    {
        return input.Split('\n')
            .Select(ParseLine)
            .ToList();
    }

    private static Dictionary<string, int> ParseLine(string line)
    {
        var matches = Regex.Matches(line, @"(\w+): (\d+)");
        return matches.ToDictionary(
            part => part.Groups[1].Value,
            part => int.Parse(part.Groups[2].Value)
        );
    }
}