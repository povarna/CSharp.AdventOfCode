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

    public int Part2(string input)
    {
        return -1;
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