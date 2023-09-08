namespace ConsoleApp.Year2015.Day07;

public class Problem
{
    public int Part1(List<string> lines)
    {
        var calc = ConsoleApp.Year2015.Day07.InputParser.Parse(lines);
        return calc["a"](new ConsoleApp.Year2015.Day07.InputParser.State());
    }

    public int Part2(List<string> lines)
    {
        var calc = ConsoleApp.Year2015.Day07.InputParser.Parse(lines);
        return calc["a"](new ConsoleApp.Year2015.Day07.InputParser.State { ["b"] = calc["a"](new ConsoleApp.Year2015.Day07.InputParser.State()) });    }
}