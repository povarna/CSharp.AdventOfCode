namespace ConsoleApp.Year2015.Day17;

public class Problem
{
    public int Part1(string input)
    {
        var sizes = GetAllSizes(input);
        return Distribute(new List<int>(), sizes, 150).ToList()
            .Count;
    }
    
    public int Part2(string input)
    {
        var sizes = GetAllSizes(input);
        var allCombinations = Distribute(new List<int>(), sizes, 150).ToList();
        var shortest = allCombinations.Select(combination => combination.Count).Min();
        return allCombinations.Count(combination => combination.Count == shortest);
    }
    
    private static List<int> GetAllSizes(string input)
    {
        return input.Split("\n")
            .Select(int.Parse)
            .ToList();
    }

    private static IEnumerable<List<int>> Distribute(List<int> used, List<int> pool, int amount)
    {
        var remaining = amount - used.Sum();
        for (var n = 0; n < pool.Count; n++)
        {
            var s = pool[n];
            if (s > remaining) continue;
            var x = used.ToList();
            x.Add(s);
            if (s == remaining)
            {
                yield return x;
            }
            else
            {
                var y = pool.Skip(n+1).ToList();
                foreach (var d in Distribute(x, y, amount))
                {
                    yield return d;
                }
            }
        }
    }
}