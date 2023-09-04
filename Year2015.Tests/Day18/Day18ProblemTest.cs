using Xunit.Abstractions;
using Year2015.Day18;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day18;

public class Day18ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper; 
    private readonly Problem _problem = new();
    private readonly string _input = FilePathUtil.ReadInputAsString(18);

    public Day18ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1(_input, 100, 100);
        _testOutputHelper.WriteLine($"AOC2015, Day18, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2(_input, 100, 100);
        _testOutputHelper.WriteLine($"AOC2015, Day18, Part2 solution result: {result}");
    }
}