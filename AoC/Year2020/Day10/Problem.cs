using System.Collections.Immutable;

namespace AoC.Year2020.Day10;

public class Problem
{
    public int Part1(string input)
    {
        var nums = ParseInput(input);

        var window = nums
            .Skip(1)
            .Zip(nums)
            .Select(p => (current: p.First, prev: p.Second))
            .ToList();
        
        var a = window.Count(t => t.current - t.prev == 1);
        var b = window.Count(t => t.current - t.prev == 3);
        return a * b;
    }

    public long Part2(string input)
    {
        var jolts = ParseInput(input);

        // dynamic programming with rolling variables a, b, c for the function values at i + 1, i + 2 and i + 3.
        var a = 1L;
        var b = 0L;
        var c = 0L;
        for (var i = jolts.Count - 2; i >= 0; i--) {
            var s =  
                (i + 1 < jolts.Count && jolts[i + 1] - jolts[i] <= 3 ? a : 0) +
                (i + 2 < jolts.Count && jolts[i + 2] - jolts[i] <= 3 ? b : 0) +
                (i + 3 < jolts.Count && jolts[i + 3] - jolts[i] <= 3 ? c : 0);
            c = b;
            b = a;
            a = s;
        }
        return a;
    }
    
    private static ImmutableList<int> ParseInput(string input)
    {
        var num = input
            .Split("\n")
            .Select(line => line.Trim())
            .Select(int.Parse)
            .OrderBy(x => x)
            .ToList();

        return ImmutableList.Create(0)
            .AddRange(num)
            .Add(num.Last() + 3);
    }

}