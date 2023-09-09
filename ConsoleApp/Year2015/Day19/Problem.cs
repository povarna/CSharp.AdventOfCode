using System.Text.RegularExpressions;

namespace ConsoleApp.Year2015.Day19;

public class Problem
{
    const string RegExPattern = @"(.*) => (.*)";

    public int Part1(string input)
    {
        var puzzleInput = ParseInput(input);
        return GenerateMolecules(puzzleInput.Transformations, puzzleInput.StartingString);
    }

    public int Part2(string input)
    {
        var puzzleInput = ParseInput(input);
        Random r = new Random();
        var st = puzzleInput.StartingString;
        var rules = puzzleInput.Transformations;
        var depth = 0;
        var i = 0;
    
        while (st != "e")
        {
            i++;
            var replacements = Replacements(rules, st, false).ToArray();
            if (replacements.Length == 0)
            {
                st = puzzleInput.StartingString;
                depth = 0;
                continue;
            }
    
            var replacement = replacements[r.Next(replacements.Length)];
            st = Replace(st, replacement.from, replacement.to, replacement.length);
            depth++;
        }
    
        return depth;
    }
    
    IEnumerable<(int from, int length, string to)> Replacements(List<Transformation> rules, string m, bool forward) {
        var ich = 0;
        while (ich < m.Length) {
            foreach (var (a, b) in rules) {
                var (from, to) = forward ? (a, b) : (b, a);
                if (ich + from.Length <= m.Length) {
                    var i = 0;
                    while (i < from.Length) {
                        if (m[ich + i] != from[i]) {
                            break;
                        }
                        i++;
                    }
                    if (i == from.Length) {
                        yield return (ich, from.Length, to);
                    }
                }
            }
            ich++;
        }
    }

    private static PuzzleInput ParseInput(string input)
    {
        var parts = input.Split("\r\n\r\n");
        if (parts.Length != 2)
            throw new ArgumentException("Invalid input!");

        var part1 = parts[0];
        var startingString = parts[1];
        var transformations = part1.Split("\n")
            .Select(line => line.Trim())
            .Select(BuildTransformation)
            .ToList();

        return new PuzzleInput(transformations, startingString);
    }

    private static Transformation BuildTransformation(string line)
    {
        var matches = Regex.Match(line, RegExPattern);
        return new Transformation(matches.Groups[1].Value, matches.Groups[2].Value);
    }

    private static int GenerateMolecules(List<Transformation> transformations, string inputText)
    {
        var generatedMolecules = new List<string>();
        foreach (var transformation in transformations)
        {
            var transformationSize = transformation.Source.Length;
            for (var i = 0; i <= inputText.Length - transformationSize; i++)
            {
                if (inputText.Substring(i, transformationSize) != transformation.Source) continue;
                generatedMolecules.Add(Replace(inputText, i, transformation.Replacement, transformationSize));
            }
        }

        return generatedMolecules.Distinct().Count();
    }
    
    private static string Replace(string st, int from, string to, int length) =>
        st.Substring(0, from) + to + st.Substring(from + length);

    private record PuzzleInput(List<Transformation> Transformations, string StartingString);

    private record Transformation(string Source, string Replacement);
}