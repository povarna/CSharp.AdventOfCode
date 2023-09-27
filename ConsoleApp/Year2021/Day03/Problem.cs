using ConsoleApp.Utils;

namespace ConsoleApp.Year2021.Day03;

public class Problem
{
    public int Part1(string input)
    {
        var grid = ParseInputAsDataGrid(input);
        var (gamaRate, epsilonRate) = GetRates(grid);
        return CalculateBinaryRate(gamaRate) * CalculateBinaryRate(epsilonRate);
    }


    public int Part2(string input)
    {
        return -1;
    }

    private static int[,] ParseInputAsDataGrid(string input)
    {
        var lines = input.Split("\n").ToArray();
        if (lines.Length < 1)
        {
            throw new ArgumentException("Invalid input!");
        }

        var n = lines.Length;
        var m = lines[0].Trim().Length;

        var grid = new int[n, m];

        for (var i = 0; i < n; i++)
        {
            var currentLine = lines[i].Trim().ToCharArray();
            for (var j = 0; j < m; j++)
            {
                var currentChar = currentLine[j];
                var v = currentChar - '0';
                grid[i, j] = v;
            }
        }

        return grid;
    }

    private static (int[] gamaRate, int[] epsilonRate) GetRates(int[,] grid)
    {
        var (m, n) = grid.GetDimensions();

        Console.WriteLine($"Grid dimensions are: {m} x {n}");

        var gamaRate = new List<int>();
        var epsilonRate = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var count = 0;
            for (var j = 0; j < m; j++)
            {
                count += grid[j, i];
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