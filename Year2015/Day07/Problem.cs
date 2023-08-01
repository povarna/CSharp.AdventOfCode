namespace Year2015.Day07;

public class Problem
{
    public int Part1(List<string> lines)
    {
        var calc = InputParser.Parse(lines);
        return calc["a"](new InputParser.State());
    }

    public int Part2(List<string> lines)
    {
        var calc = InputParser.Parse(lines);
        return calc["a"](new InputParser.State { ["b"] = calc["a"](new InputParser.State()) });    }
}