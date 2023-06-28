using Xunit.Abstractions;
using Year2015.Day06;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day06;

public class Day06ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Problem _problem = new();
    private readonly List<string> _lines = FilePathUtil.ReadInputAsListOfString(6);

    public Day06ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1(_lines);
        _testOutputHelper.WriteLine($"AOC2015, Day06, Part2 solution result: {result}");
    }

    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2(_lines);
        _testOutputHelper.WriteLine($"AOC2015, Day06, Part2 solution result: {result}");
    }
}