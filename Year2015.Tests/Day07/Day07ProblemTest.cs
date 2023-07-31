using Xunit.Abstractions;
using Year2015.Day07;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day07;

public class Day07ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper; 
    private readonly Problem _problem = new();
    private readonly List<String> _lines = FilePathUtil.ReadInputAsListOfString(7);

    public Day07ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1(_lines);
        _testOutputHelper.WriteLine($"AOC2015, Day07, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2(_lines);
        _testOutputHelper.WriteLine($"AOC2015, Day07, Part2 solution result: {result}");
    }
}