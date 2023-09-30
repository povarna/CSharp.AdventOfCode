namespace AoC.Year2021.Day08;

public class Problem
{
    public int Part1(string input)
    {
        var validLengthPatterns = new HashSet<int> { 2, 3, 4, 7 };
        return input.Split("\n")
            .Select(line => line.Split("|"))
            .Select(parts => parts[1])
            .Select(patterns => patterns.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .SelectMany(x => x)
            .Select(pattern => pattern.Trim())
            .Count(pattern => validLengthPatterns.Contains(pattern.Length));
    }

    public int Part2(string input)
    {
        return -1;
    }
}