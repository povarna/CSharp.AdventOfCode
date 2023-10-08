namespace AoC.Year2021.Day09;

public class Problem
{
    public int Part1(string input)
    {
        var grid = ParseInput(input);
        var list = GetMinPoints(grid);
        return list.Sum(coordinate => grid[coordinate.x][coordinate.y]) + list.Count;
    }

    public int Part2(string input)
    {
        return -1;
    }

    private static int[][] ParseInput(string input) =>
        input.Split("\n")
            .Select(line =>
                line.Trim().ToCharArray()
                    .Select(c => int.Parse(c.ToString()))
                    .ToArray()
            )
            .ToArray();

    private static List<(int x, int y)> GetMinPoints(int[][] grid)
    {
        var minPointsList = new List<(int x, int y)>();

        var m = grid.Length;
        var n = grid[0].Length;

        Console.WriteLine($"Grid dimensions: {m} x {n}");

        // Get all the inside matrix values
        for (var i = 1; i < m - 1; i++)
        {
            for (var j = 1; j < n - 1; j++)
            {
                {
                    if (grid[i][j] < grid[i][j - 1] &&
                        grid[i][j] < grid[i - 1][j] &&
                        grid[i][j] < grid[i + 1][j] &&
                        grid[i][j] < grid[i][j + 1])
                    {
                        minPointsList.Add((i, j));
                    }
                }
            }
        }

        // Get the first and the last row
        for (var j = 1; j < n - 1; j++)
        {
            if (grid[0][j] < grid[0][j - 1] &&
                grid[0][j] < grid[0][j + 1] &&
                grid[0][j] < grid[1][j])
            {
                minPointsList.Add((0, j));
            }

            if (grid[m - 1][j] < grid[m - 1][j - 1] &&
                grid[m - 1][j] < grid[m - 1][j + 1] &&
                grid[m - 1][j] < grid[m - 2][j])
            {
                minPointsList.Add((m - 1, j));
            }
        }

        // Get the first and the last column
        for (var i = 1; i < m - 1; i++)
        {
            if (grid[i][0] < grid[i - 1][0] &&
                grid[i][0] < grid[i + 1][0] &&
                grid[i][0] < grid[i][1])
            {
                minPointsList.Add((i, 0));
            }

            if (grid[i][n - 1] < grid[i - 1][n - 1] &&
                grid[i][n - 1] < grid[i + 1][n - 1] &&
                grid[i][n - 1] < grid[i][n - 2])
            {
                minPointsList.Add((i, n - 1));
            }
        }

        // Add corners
        if (grid[0][0] < grid[1][0] &&
            grid[0][0] < grid[0][1])
        {
            minPointsList.Add((0, 0));
        }

        if (grid[0][n - 1] < grid[0][n - 2] &&
            grid[0][n - 1] < grid[1][n - 1])
        {
            minPointsList.Add((0, n - 1));
        }

        if (grid[m - 1][0] < grid[m - 1][1] &&
            grid[m - 1][0] < grid[m - 2][0])
        {
            minPointsList.Add((m - 1, 0));
        }

        if (grid[m - 1][n - 1] < grid[m - 2][n - 1] &&
            grid[m - 1][n - 1] < grid[m - 1][n - 2])
        {
            minPointsList.Add((m - 1, n - 1));
        }

        return minPointsList;
    }
}