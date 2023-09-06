﻿using Xunit.Abstractions;
using Year2015.Day21;
using Year2015.Tests.Utils;

namespace Year2015.Tests.Day21;

public class Day21ProblemTest
{
    private readonly ITestOutputHelper _testOutputHelper; 
    private readonly Problem _problem = new();
    private readonly string _input = FilePathUtil.ReadInputAsString(21);

    public Day21ProblemTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Part1Solution()
    {
        var result = _problem.Part1(_input);
        _testOutputHelper.WriteLine($"AOC2015, Day21, Part1 solution result: {result}");
    }
    
    [Fact]
    public void Part2Solution()
    {
        var result = _problem.Part2(_input);
        _testOutputHelper.WriteLine($"AOC2015, Day21, Part2 solution result: {result}");
    }
}