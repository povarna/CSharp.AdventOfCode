using Xunit.Abstractions;
using Year2015.Day15;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day15;

public class Day15ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper; 
    private readonly Problem _problem = new();
    private readonly string _input = FilePathUtil.ReadInputAsString(15);

    public Day15ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1(_input);
        _testOutputHelper.WriteLine($"AOC2015, Day15, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2(_input);
        _testOutputHelper.WriteLine($"AOC2015, Day15, Part2 solution result: {result}");
    }
}