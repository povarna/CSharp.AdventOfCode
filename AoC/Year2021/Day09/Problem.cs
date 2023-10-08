using System.Collections.Immutable;

namespace AoC.Year2021.Day09;

public class Problem
{
    public int Part1(string input)
    {
        var map = GetMap(input);
        return GetLowPoints(map).Select(point => 1 + map[point]).Sum();
    }

    public int Part2(string input)
    {
        var map = GetMap(input);
        return GetLowPoints(map)
            .Select(p => BasinSize(map, p))
            .OrderByDescending(basinSize => basinSize)
            .Take(3)
            .Aggregate(1, (m, basinSize) => m * basinSize);
    }

    private static ImmutableDictionary<(int x, int y), int> GetMap(string input)
    {
        var map = input.Split("\n").Select(line => line.Trim()).ToArray();
        var dict = new Dictionary<(int, int), int>();

        foreach (var i in Enumerable.Range(0, map.Length))
        {
            foreach (var j in Enumerable.Range(0, map[0].Length))
            {
                dict.Add((i, j), map[i][j] - '0');
            }
        }

        return dict.ToImmutableDictionary();
    }

    private static int BasinSize(ImmutableDictionary<(int x, int y), int> map, (int x, int y) point)
    {
        var filled = new HashSet<(int x, int y)> { point };
        var queue = new Queue<(int x, int y)>(filled);

        while (queue.Any())
        {
            foreach (var neighbour in Neighbours(queue.Dequeue()).Except(filled))
            {
                if (map.GetValueOrDefault(neighbour, 9) != 9)
                {
                    queue.Enqueue(neighbour);
                    filled.Add(neighbour);
                }
            }
        }

        return filled.Count;
    }

    private static IEnumerable<(int x, int y)> GetLowPoints(ImmutableDictionary<(int x, int y), int> map) =>
        map.Keys
            .Where(point => 
                Neighbours(point)
                    .All(neighbour => map[point] < map.GetValueOrDefault(neighbour, 9)))
            .ToList();

    private static IEnumerable<(int x, int y)> Neighbours((int x, int y) point) =>
        new[]
        {
            (point.x - 1, point.y),
            (point.x + 1, point.y),
            (point.x, point.y - 1),
            (point.x, point.y + 1)
        };

    private static int[][] ParseInput(string input) =>
        input.Split("\n")
            .Select(line =>
                line.Trim().ToCharArray()
                    .Select(c => int.Parse(c.ToString()))
                    .ToArray()
            )
            .ToArray();
}