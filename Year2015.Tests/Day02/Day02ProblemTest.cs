using Xunit.Abstractions;
using Year2015.Day02;
using static Year2015.Tests.Utils.FilePathUtil;

namespace Year2015.Tests.Day02;

public class Day02ProblemTest
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly Problem _problem = new();
    private readonly string _input = ReadInputAsString(day: 2);

    public Day02ProblemTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var part1 = _problem.Part1(_input);
        _outputHelper.WriteLine($"AOC2015, Day02, Part1 solution result: {part1}");
    }

    [Fact]
    public void Part2Solution()
    {
        var part1 = _problem.Part2(_input);
        _outputHelper.WriteLine($"AOC2015, Day02, Part2 solution result: {part1}");
    }
}