using Xunit.Abstractions;
using Year2015.Day12;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day12;

public class Day12ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper; 
    private readonly Problem _problem = new();
    private readonly string _input = FilePathUtil.ReadInputAsString(12);

    public Day12ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1(_input);
        _testOutputHelper.WriteLine($"AOC2015, Day12, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2(_input);
        _testOutputHelper.WriteLine($"AOC2015, Day12, Part2 solution result: {result}");
    }
}