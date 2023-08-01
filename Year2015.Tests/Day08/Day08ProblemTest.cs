using Xunit.Abstractions;
using Year2015.Day08;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day08;

public class Day08ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper; 
    private readonly Problem _problem = new();
    private readonly string _lines = FilePathUtil.ReadInputAsString(8);

    public Day08ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1(_lines);
        _testOutputHelper.WriteLine($"AOC2015, Day08, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2(_lines);
        _testOutputHelper.WriteLine($"AOC2015, Day08, Part2 solution result: {result}");
    }
    
}