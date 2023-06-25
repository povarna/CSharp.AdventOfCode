using Xunit.Abstractions;
using Year2015.Day02;
using static Year2015.Tests.Utils.FilePathUtil;

namespace Year2015.Tests.Day02;

public class Day02ProblemFixture
{
    public Problem Problem => new();
}

public class Day02ProblemTest: IClassFixture<Day02ProblemFixture>
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly Day02ProblemFixture _day02ProblemFixture;

    public Day02ProblemTest(ITestOutputHelper outputHelper, Day02ProblemFixture day02ProblemFixture)
    {
        _outputHelper = outputHelper;
        _day02ProblemFixture = day02ProblemFixture;
    }
    
    [Fact]
    public void Part1Solution()
    {
        var part1 = _day02ProblemFixture.Problem.Part1(ReadInputAsString(2, "input.txt"));
        _outputHelper.WriteLine($"AOC2015, Day02, Part1 solution result: {part1}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var part1 = _day02ProblemFixture.Problem.Part2(ReadInputAsString(2, "input.txt"));
        _outputHelper.WriteLine($"AOC2015, Day02, Part2 solution result: {part1}");
    }
}