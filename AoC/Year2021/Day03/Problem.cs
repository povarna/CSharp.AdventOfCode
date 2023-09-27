using AoC.Utils;

namespace AoC.Year2021.Day03;

public class Problem
{
    public int Part1(string input)
    {
        var grid = ParseInputAsAnArray(input);
        var (gamaRate, epsilonRate) = GetRates(grid);
        return CalculateBinaryRate(gamaRate) * CalculateBinaryRate(epsilonRate);
    }

    public int Part2(string input)
    {
        var grid = ParseInputAsAnArray(input);
        // grid.PrintGrid();

        var oxygenGeneratorRating = GetRating(grid, false);
        var co2ScrubberRating = GetRating(grid, true);
        if (oxygenGeneratorRating.Length != 1 || co2ScrubberRating.Length != 1)
        {
            throw new Exception("Invalid results. The rating matrix should contains only one array!");
        }

        return CalculateBinaryRate(oxygenGeneratorRating[0]) * CalculateBinaryRate(co2ScrubberRating[0]);
    }

    private static int[][] GetRating(int[][] grid, bool invertWiningCondition)
    {
        var i = 0;
        while (grid.Length > 1)
        {
            var newGrid = GetRating(grid, i, invertWiningCondition);
            // newGrid.PrintGrid();
            i += 1;
            grid = newGrid;
        }

        return grid;
    }

    private static int[][] GetRating(int[][] grid, int bitPosition, bool invertWiningCondition)
    {
        var (m, n) = grid.GetDimensions();
        // Console.WriteLine($"Grid dimensions are: {m} x {n}");

        var count = 0;
        for (var j = 0; j < m; j++)
        {
            count += grid[j][bitPosition];
        }

        var winingBit = CalculateWiningBit(invertWiningCondition, count, m);

        var tmpGrid = new List<int[]>();
        for (var t = 0; t < m; t++)
        {
            if (grid[t][bitPosition] == winingBit)
            {
                tmpGrid.Add(grid[t]);
            }
        }

        return tmpGrid.ToArray();
    }

    private static int CalculateWiningBit(bool invertWiningCondition, int nrOfOnes, int nrOfRows)
    {
        int winingBit;
        if (invertWiningCondition)
        {
            winingBit = nrOfOnes >= nrOfRows - nrOfOnes ? 0 : 1;
        }
        else
        {
            winingBit = nrOfOnes >= nrOfRows - nrOfOnes ? 1 : 0;
        }

        return winingBit;
    }

    private static int[][] ParseInputAsAnArray(string input)
    {
        return input.Split("\n")
            .Select(line => line.Trim())
            .Select(line => line.ToCharArray()
                .Select(c => int.Parse(c.ToString()))
                .ToArray()
            )
            .ToArray();
    }

    private static (int[] gamaRate, int[] epsilonRate) GetRates(IReadOnlyList<int[]> grid)
    {
        var gamaRate = new List<int>();
        var epsilonRate = new List<int>();

        var m = grid.Count;
        var n = grid[0].Length;
        Console.WriteLine($"Grid dimensions are: {m} x {n}");

        for (var i = 0; i < n; i++)
        {
            var count = 0;
            for (var j = 0; j < m; j++)
            {
                count += grid[j][i];
            }


            if (count > m - count)
            {
                gamaRate.Add(1);
                epsilonRate.Add(0);
            }
            else
            {
                gamaRate.Add(0);
                epsilonRate.Add(1);
            }
        }

        return (gamaRate.ToArray(), epsilonRate.ToArray());
    }

    private static int CalculateBinaryRate(IReadOnlyList<int> binaryRate)
    {
        var n = 0;
        for (var i = binaryRate.Count - 1; i >= 0; i--)
        {
            n += (int)Math.Pow(2, binaryRate.Count - 1 - i) * binaryRate[i];
        }

        return n;
    }
}