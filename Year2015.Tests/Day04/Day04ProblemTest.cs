using Xunit.Abstractions;
using Year2015.Day04;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day04;

public class Day04ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Problem _problem = new();
    private readonly string _input = FilePathUtil.ReadInputAsString(day: 4);

    public Day04ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1(_input);
        _testOutputHelper.WriteLine($"AOC2015, Day04, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2(_input);
        _testOutputHelper.WriteLine($"AOC2015, Day04, Part2 solution result: {result}");
    }
}