namespace AoC.Year2021.Day11;

public class Problem
{
    public int Part1(string input) => CountTheNumberOfFlashes(input).Take(100).Sum();

    public int Part2(string input) => CountTheNumberOfFlashes(input).TakeWhile(flash => flash != 100).Count() + 1;

    private IEnumerable<int> CountTheNumberOfFlashes(string input)
    {
        var map = GetMap(input);

        while (true)
        {
            var queue = new Queue<Pos>();
            var flashed = new HashSet<Pos>();

            foreach (var key in map.Keys)
            {
                map[key]++;
                if (map[key] == 10)
                {
                    queue.Enqueue(key);
                }
            }

            while (queue.Any())
            {
                var pos = queue.Dequeue();
                flashed.Add(pos);
                foreach (var neighbour in Neighbours(pos))
                {
                    if (!map.ContainsKey(neighbour)) continue;

                    map[neighbour]++;
                    if (map[neighbour] == 10)
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }

            // reset energy level
            foreach (var pos in flashed)
            {
                map[pos] = 0;
            }

            yield return flashed.Count;
        }
    }

    private static Dictionary<Pos, int> GetMap(string input)
    {
        var map = input.Split("\n")
            .Select(line => line.Trim())
            .ToArray();

        var dict = new Dictionary<Pos, int>();
        foreach (var i in Enumerable.Range(0, map.Length))
        {
            foreach (var j in Enumerable.Range(0, map[0].Length))
            {
                dict.Add(new Pos(i, j), map[i][j] - '0');
            }
        }

        return dict;
    }

    private static IEnumerable<Pos> Neighbours(Pos pos)
    {
        var arr = new[] { -1, 0, 1 };
        foreach (var i in arr)
        foreach (var j in arr)
            if (i != 0 || j != 0)
                yield return new Pos(pos.x + i, pos.y + j);
    }

    private record Pos(int x, int y);
}