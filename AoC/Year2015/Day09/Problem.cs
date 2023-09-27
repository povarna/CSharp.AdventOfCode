using System.Text.RegularExpressions;

namespace AoC.Year2015.Day09;

public class Problem
{
    private readonly string _pattern = @"(\w+) to (\w+) = (\w+)";

    public int Part1(string input)
    {
        var directions = GetRoutes(input);
        var cities = directions.Keys.Select(k => k.Item1).Distinct().ToArray();
        var permutations = Permutations(cities).ToArray();

        return GetSumOfAllDistances(permutations, directions)
            .Min();
    }
    
    public int Part2(string input)
    {
        var directions = GetRoutes(input);
        var cities = directions.Keys.Select(k => k.Item1).Distinct().ToArray();
        var permutations = Permutations(cities).ToArray();

        return GetSumOfAllDistances(permutations, directions)
            .Max();
    }

    private Dictionary<(string, string), int> GetRoutes(string input)
    {
        return input.Split("\n").SelectMany(line =>
        {
            var values = ParseLine(line);
            var (fromTown, toTown) = (values[0], values[1]);
            var distance = int.Parse(values[2]);
            return new[]
            {
                (towns: (fromTown, toTown), distance),
                (towns: (toTown, fromTown), distance),
            };
        }).ToDictionary(p => p.towns, p => p.distance);
    }

    private string[] ParseLine(string line)
    {
        var match = Regex.Match(line, _pattern);
        if (!match.Success)
        {
            return Array.Empty<string>();
        }

        return match
            .Groups
            .Cast<Group>()
            .Skip(1)
            .Select(g => g.Value)
            .ToArray();
    }

    private IEnumerable<string[]> Permutations(string[] cities)
    {
        IEnumerable<string[]> PermutationsRec(int i)
        {
            if (i == cities.Length)
            {
                yield return cities.ToArray();
            }

            for (var j = i; j < cities.Length; j++)
            {
                (cities[i], cities[j]) = (cities[j], cities[i]);
                foreach (var perm in PermutationsRec(i + 1))
                {
                    yield return perm;
                }

                (cities[i], cities[j]) = (cities[j], cities[i]);
            }
        }

        return PermutationsRec(0);
    }

    private IEnumerable<int> GetSumOfAllDistances(string[][] strings, Dictionary<(string, string), int> dictionary) =>
        strings.Select(route =>
            route.Zip(
                    route.Skip(1),
                    (a, b) => dictionary[(a, b)]
                )
                .Sum()
        );
}