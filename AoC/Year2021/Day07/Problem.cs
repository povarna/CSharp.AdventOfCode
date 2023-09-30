namespace AoC.Year2021.Day07;

public class Problem
{
    public int Part1(string input) => CalculateMinFuel(input, false);

    public int Part2(string input) => CalculateMinFuel(input, true);

    private static int CalculateMinFuel(string input, bool additionalDistanceCost)
    {
        var positions = input.Split(",")
            .Select(s => s.Trim())
            .Select(int.Parse)
            .ToArray();

        var maxPosition = positions.Max();
        var leastFuel = int.MaxValue;

        for (var i = 0; i < maxPosition; i++)
        {
            /*
             *  dist + (dist + 1) / 2 is the mathematical formula for summing all the numbers from 1 to dist
             *    Ex: dist = 4. (1 + 2 + 3 + 4 = 10) equivalent with (4 * 5 / 2)
             */
            var fuel = positions
                .Select(position => Math.Abs(i - position))
                .Select(dist => additionalDistanceCost ? dist * (dist + 1) / 2 : dist)
                .Sum();

            leastFuel = Math.Min(leastFuel, fuel);
        }

        return leastFuel;
    }
}