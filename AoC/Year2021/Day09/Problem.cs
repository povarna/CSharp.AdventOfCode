namespace AoC.Year2021.Day09;

public class Problem
{
    public int Part1(string input)
    {
        var grid = ParseInput(input);
        var m = grid.Length;
        var n = grid[0].Length;

        Console.WriteLine($"Grid dimensions: {m} x {n}");

        var count = 0;
        // Get all the inside matrix values
        for (var i = 1; i < m - 1; i++)
        {
            for (var j = 1; j < n - 1; j++)
            {
                {
                    count += grid[i][j] < grid[i][j - 1] &&
                             grid[i][j] < grid[i - 1][j] &&
                             grid[i][j] < grid[i + 1][j] &&
                             grid[i][j] < grid[i][j + 1]
                        ? grid[i][j] + 1
                        : 0;
                }
            }
        }

        // Get the first and the last row
        for (var j = 1; j < n - 1; j++)
        {
            count += grid[0][j] < grid[0][j - 1] &&
                     grid[0][j] < grid[0][j + 1] &&
                     grid[0][j] < grid[1][j]
                ? grid[0][j] + 1
                : 0;

            count += grid[m - 1][j] < grid[m - 1][j - 1] &&
                     grid[m - 1][j] < grid[m - 1][j + 1] &&
                     grid[m - 1][j] < grid[m - 2][j]
                ? grid[m - 1][j] + 1
                : 0;
        }

        // Get the first and the last column
        for (var i = 1; i < m - 1; i++)
        {
            count += grid[i][0] < grid[i - 1][0] &&
                     grid[i][0] < grid[i + 1][0] &&
                     grid[i][0] < grid[i][1]
                ? grid[i][0] + 1
                : 0;

            count += grid[i][n - 1] < grid[i - 1][n - 1] &&
                     grid[i][n - 1] < grid[i + 1][n - 1] &&
                     grid[i][n - 1] < grid[i][n - 2]
                ? grid[i][n - 1]  + 1
                : 0;
        }
        
        // Add corners
        count += grid[0][0] < grid[1][0] &&
                 grid[0][0] < grid[0][1]
            ? grid[0][0] + 1
            : 0;
        count += grid[0][n-1] < grid[0][n-2] &&
                 grid[0][n-1] < grid[1][n-1]
            ? grid[0][n-1] + 1
            : 0;
        count += grid[m-1][0] < grid[m-1][1] &&
                 grid[m-1][0] < grid[m-2][0]
            ? grid[m-1][0]  + 1
            : 0;
        count += grid[m-1][n-1] < grid[m-2][n-1] &&
                 grid[m-1][n-1] < grid[m-1][n-2]
            ? grid[m-1][n-1] + 1
            : 0;

        return count;
    }

    public int Part2(string input)
    {
        return -1;
    }

    private int[][] ParseInput(string input) =>
        input.Split("\n")
            .Select(line =>
                line.Trim().ToCharArray()
                    .Select(c => int.Parse(c.ToString()))
                    .ToArray()
            )
            .ToArray();
}