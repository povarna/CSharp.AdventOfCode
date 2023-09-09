namespace ConsoleApp.Year2015.Day07;

public class Problem
{
    public int Part1(string input)
    {
        var lines = input.Split("\n").ToList();
        var calc = InputParser.Parse(lines);
        return calc["a"](new InputParser.State());
    }

    public int Part2(string input)
    {
        var lines = input.Split("\n").ToList();
        var calc = InputParser.Parse(lines);
        return calc["a"](new InputParser.State
            { ["b"] = calc["a"](new InputParser.State()) });
    }
}