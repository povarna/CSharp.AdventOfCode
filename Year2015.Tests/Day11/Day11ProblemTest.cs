using Xunit.Abstractions;
using Year2015.Day11;

namespace Year2015.Tests.Day11;

public class Day11ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper; 
    private readonly Problem _problem = new();

    public Day11ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1("hxbxwxba");
        _testOutputHelper.WriteLine($"AOC2015, Day11, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2("hxbxwxba");
        _testOutputHelper.WriteLine($"AOC2015, Day11, Part2 solution result: {result}");
    }
}