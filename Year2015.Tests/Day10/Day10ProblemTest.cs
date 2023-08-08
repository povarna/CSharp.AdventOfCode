using Xunit.Abstractions;
using Year2015.Day10;

namespace Year2015.Tests.Day10;

public class Day10ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper; 
    private readonly Problem _problem = new();

    public Day10ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1("3113322113");
        _testOutputHelper.WriteLine($"AOC2015, Day10, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2("3113322113");
        _testOutputHelper.WriteLine($"AOC2015, Day10, Part2 solution result: {result}");
    }
}