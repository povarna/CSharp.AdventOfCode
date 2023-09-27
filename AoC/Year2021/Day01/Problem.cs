namespace AoC.Year2021.Day01;

public class Problem
{
    public int Part1(string input)
    {
        var measurements = ParseInput(input);
        return CalculateGtValues(measurements);
    }

    public int Part2(string input)
    {
        var measurements = ParseInput(input);
        var acc = new List<int>();
        for (var i = 0; i < measurements.Length - 2; i++)
        {
            var partialSum = 0;
            for (var j = i; j <= i + 2; j++)
            {
                partialSum += measurements[j];
            }

            acc.Add(partialSum);
        }

        return CalculateGtValues(acc);
    }

    private static int CalculateGtValues(IReadOnlyList<int> measurements) =>
        Enumerable
            .Range(1, measurements.Count - 1)
            .Aggregate(0, (increaseCount, i) =>
                increaseCount + (measurements[i] > measurements[i - 1] ? 1 : 0)
            );


    private static int[] ParseInput(string input) =>
        input.Split("\n")
            .Select(int.Parse)
            .ToArray();
}