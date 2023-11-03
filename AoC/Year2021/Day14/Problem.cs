using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using AoC.Utils;

namespace AoC.Year2021.Day14;

public class Problem
{
    public long Part1(string input) => Solve(input, 10);
    public long Part2(string input) => Solve(input, 40);

    private static long Solve(string input, int steps)
    {
        var polymerFormula = ParseInput(input);
        var polymerTemplate = polymerFormula.polymerTemplate;
        var insertionRules = polymerFormula.insertionRules;

        var moleculeCount = new Dictionary<string, long>();

        // Initial traverse of the polymerTemplate
        for (var i = 0; i < polymerTemplate.Length - 1; i++)
        {
            var st = polymerTemplate.Substring(i, 2);
            moleculeCount[st] = moleculeCount.GetValueOrDefault(st) + 1;
        }

        // Update dictionary
        for (var j = 0; j < steps; j++)
        {
            var updates = new Dictionary<string, long>();

            foreach (var (molecule, count) in moleculeCount)
            {
                var insertionStr = insertionRules[molecule];
                var str1 = $"{molecule[0]}{insertionStr}";
                var str2 = $"{insertionStr}{molecule[1]}";
                updates[str1] = updates.GetValueOrDefault(str1) + count;
                updates[str2] = updates.GetValueOrDefault(str2) + count;
            }

            moleculeCount = updates;
        }

        // count
        var elementsCount = new Dictionary<char, long>();
        foreach (var (molecule, count) in moleculeCount)
        {
            var a = molecule[0];
            elementsCount[a] = elementsCount.GetValueOrDefault(a) + count;
        }

        // add the last element
        elementsCount[polymerTemplate.Last()]++;

        return elementsCount.Values.Max() - elementsCount.Values.Min();
    }

    private static PolymerFormula ParseInput(string input)
    {
        var separator = " -> ";

        var parts = input.Split(Constants.END_OF_LINE);
        var rules = parts[1].Split("\n")
            .Select(l => l.Trim().Split(separator))
            .ToDictionary(arr => arr[0].Trim(), arr => arr[1].Trim());
        return new PolymerFormula(parts[0].Trim(), rules);
    }

    private record PolymerFormula(string polymerTemplate, Dictionary<string, string> insertionRules);
}