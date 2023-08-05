using Xunit.Abstractions;
using Year2015.Day09;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day09;

public class Day09ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper; 
    private readonly Problem _problem = new();
    private readonly string _lines = FilePathUtil.ReadInputAsString(9);

    public Day09ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1(_lines);
        _testOutputHelper.WriteLine($"AOC2015, Day09, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2(_lines);
        _testOutputHelper.WriteLine($"AOC2015, Day09, Part2 solution result: {result}");
    }
}