using Xunit.Abstractions;
using Year2015.Day05;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day05;

public class Day05ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Problem _problem = new();
    private readonly List<string> _words = FilePathUtil.ReadInputAsListOfString(5);
    
    public Day05ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1(_words);
        _testOutputHelper.WriteLine($"AOC2015, Day05, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2(_words);
        _testOutputHelper.WriteLine($"AOC2015, Day05, Part2 solution result: {result}");
    }
}