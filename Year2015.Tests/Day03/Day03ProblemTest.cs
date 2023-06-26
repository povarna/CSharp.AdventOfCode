using Xunit.Abstractions;
using Year2015.Day03;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day03;

public class Day03ProblemFixture
{
    public readonly Problem Problem = new();
}

public class Day03ProblemTest: IClassFixture<Day03ProblemFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Day03ProblemFixture _day03ProblemFixture;
    private readonly string _input = FilePathUtil.ReadInputAsString(3, "input.txt");

    public Day03ProblemTest(ITestOutputHelper testOutputHelper, Day03ProblemFixture day03ProblemFixture)
    {
        _testOutputHelper = testOutputHelper;
        _day03ProblemFixture = day03ProblemFixture;
    }
    
    [Fact]
    public void Part1Solution()
    {
        var result= _day03ProblemFixture.Problem.Part1(_input);
        _testOutputHelper.WriteLine($"AOC2015, Day03, Part1 solution result: {result}");
    }

    [Fact]
    public void Part2Solution()
    {
        var result = _day03ProblemFixture.Problem.Part2(_input);
        _testOutputHelper.WriteLine($"AOC2015, Day03, Part2 solution result: {result}");
    }
}