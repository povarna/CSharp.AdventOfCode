using Xunit.Abstractions;
using Year2015.Day01;
using static Year2015.Tests.Utils.FilePathUtil;

namespace Year2015.Tests.Day01;

public class Day01ProblemTest
{
    private readonly Problem _problem = new();
    private readonly ITestOutputHelper _iTestOutputHelper;
    private readonly string _input = ReadInputAsString(day: 1);

    public Day01ProblemTest(ITestOutputHelper iTestOutputHelper)
    {
        _iTestOutputHelper = iTestOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var part1 = _problem.Part1(_input);
        _iTestOutputHelper.WriteLine($"AOC2015, Day01, Part1 solution result: {part1}");
    }

    [Fact]
    public void Part2Solution()
    {
        var part2 = _problem.Part2(_input);
        _iTestOutputHelper.WriteLine($"AOC2015, Day01, Part2 solution result: {part2}");
    }
}