namespace AoC.Year2021.Day07;

public class Problem
{
    public int Part1(string input) => CalculateMinFuel(input);

    public int Part2(string input)
    {
        return -1;
    }

    private static int CalculateMinFuel(string input)
    {
        var positions = input.Split(",")
            .Select(s =>s.Trim())
            .Select(int.Parse)
            .ToArray();

        var maxPosition = positions.Max();
        var leastFuel = int.MaxValue;

        for (var i = 0; i < maxPosition; i++)
        {
            var fuel = positions.Sum(position => Math.Abs(i - position));
            leastFuel = Math.Min(leastFuel, fuel);
        }

        return leastFuel;
    }
}