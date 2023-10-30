using System.Collections.Immutable;

namespace AoC.Year2021.Day12;

public class Problem
{
    public int Part1(string input) => Explore(input, false);

    public int Part2(string input) => Explore(input, true);

    private static int Explore(string input, bool part2)
    {
        var map = GetMap(input);
        
        int PathCount(string currentCave, ImmutableHashSet<string> visitedCaves, bool anySamllCaveWasVisitedTwice)
        {
            if (currentCave == "end")
            {
                return 1;
            }

            var res = 0;
            foreach (var cave in map[currentCave])
            {
                var isBigCave = cave.ToUpper() == cave;
                var seen = visitedCaves.Contains(cave);
                if (!seen || isBigCave)
                {
                    res += PathCount(cave, visitedCaves.Add(cave), anySamllCaveWasVisitedTwice);
                } else if (part2 && !isBigCave && cave != "start" && !anySamllCaveWasVisitedTwice)
                {
                    res += PathCount(cave, visitedCaves, true);
                }
            }

            return res;
        }

        return PathCount("start", ImmutableHashSet.Create<string>("start"), false);
    }

    private static Dictionary<string, string[]> GetMap(string input)
    {
        var lines = input.Split("\n").Select(line => line.Trim());
        var connections = new List<(string, string)>();
        foreach (var line in lines)
        {
            var parts = line.Split('-');
            var caveA = parts[0];
            var caveB = parts[1];

            var c = new[]
            {
                (From: caveA, To: caveB),
                (From: caveB, To: caveA)
            };

            connections.AddRange(c);
        }

        var dict = connections.GroupBy(p => p.Item1)
            .ToDictionary(
                g => g.Key,
                g => g.Select(connection =>
                    connection.Item2
                ).ToArray()
            );

        return dict;
    }
}