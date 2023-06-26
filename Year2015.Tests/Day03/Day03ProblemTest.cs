using Xunit.Abstractions;
using Year2015.Day03;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day03;

public class Day03ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day03ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    [Fact]
    public void Part1Solution()
    {
        var problem = new Problem();
        var input = FilePathUtil.ReadInputAsString(3, "input.txt");
        var solution= problem.Part1(input);
        _testOutputHelper.WriteLine($"{solution}");
    }
}