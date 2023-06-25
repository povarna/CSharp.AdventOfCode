using Xunit.Abstractions;
using Year2015.Day01;
using static Year2015.Tests.Utils.FilePathUtil;

namespace Year2015.Tests.Day01;

public class Day01ProblemFixture
{
    public Problem Problem => new();
}

public class Day01ProblemTest: IClassFixture<Day01ProblemFixture>
{
    private readonly ITestOutputHelper _iTestOutputHelper;
    private readonly Day01ProblemFixture _day01ProblemFixture;

    public Day01ProblemTest(ITestOutputHelper iTestOutputHelper, Day01ProblemFixture day01ProblemFixture)
    {
        _iTestOutputHelper = iTestOutputHelper;
        _day01ProblemFixture = day01ProblemFixture;
    }
    
    [Fact]
    public void Part1Solution()
    {
        var input = ReadInputAsString(1, "input.txt");
        var part1 = _day01ProblemFixture.Problem.Part1(input);
        _iTestOutputHelper.WriteLine($"AOC2015, Day01, Part1 solution result: {part1}");
    }

    [Fact]
    public void Part2Solution()
    {
        var input = ReadInputAsString(1, "input.txt");
        var part2 = _day01ProblemFixture.Problem.Part2(input);
        _iTestOutputHelper.WriteLine($"AOC2015, Day01, Part2 solution result: {part2}");
    }

}