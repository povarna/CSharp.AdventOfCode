namespace AoC.Year2015.Day18;

public class Problem
{
    private static readonly HashSet<(int, int)> FixedPoints = new();
    private const int M = 100;
    private const int N = 100;
    
    public int Part1(string input)
    {
        var grid = ParseInput(input, M, N);
        for (var i = 0; i < 100; i++)
        {
            grid = UpdateGrid(grid, M, N, false);
        }

        return CountOpenLights(M, N, grid);
    }


    public int Part2(string input)
    {
        FixedPoints.Add((0, 0));
        FixedPoints.Add((0, N - 1));
        FixedPoints.Add((M - 1, 0));
        FixedPoints.Add((M - 1, N - 1));

        var grid = ParseInput(input, M, N);
        SetFixedPoints(grid, FixedPoints);

        for (var i = 0; i < 100; i++)
        {
            grid = UpdateGrid(grid, M, N, true);
            SetFixedPoints(grid, FixedPoints);
        }

        return CountOpenLights(M, N, grid);
    }

    private static void SetFixedPoints(char[,] grid, HashSet<(int, int)> fixedPoints)
    {
        foreach (var fixedPoint in fixedPoints)
        {
            grid[fixedPoint.Item1, fixedPoint.Item2] = '#';
        }
    }

    private static char[,] ParseInput(string input, int m, int n)
    {
        var lines = input.Split("\n");
        var grid = new char[m, n];

        for (var i = 0; i < m; i++)
        {
            var currentLine = lines[i].Trim().ToCharArray();
            for (var j = 0; j < n; j++)
            {
                grid[i, j] = currentLine[j];
            }
        }

        return grid;
    }

    private static char[,] UpdateGrid(char[,] grid, int m, int n, bool hasFixedPoints)
    {
        var tmpGrid = new char[m, n];
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (hasFixedPoints && FixedPoints.Contains((i, j)))
                    continue;

                var allPossibleNeighbors = new List<(int, int)>
                {
                    (i - 1, j - 1), (i - 1, j), (i - 1, j + 1),
                    (i, j - 1), (i, j + 1),
                    (i + 1, j - 1), (i + 1, j), (i + 1, j + 1)
                };

                var neighbors = allPossibleNeighbors
                    .Where(t => t is { Item1: >= 0, Item2: >= 0 })
                    .Where(t => t.Item1 < m && t.Item2 < n)
                    .Select(p => grid[p.Item1, p.Item2])
                    .Count(v => v == '#');

                if (grid[i, j] == '#')
                {
                    tmpGrid[i, j] = neighbors is < 2 or > 3 ? '.' : '#';
                }
                else
                {
                    tmpGrid[i, j] = neighbors == 3 ? '#' : '.';
                }
            }
        }

        return tmpGrid;
    }

    private static int CountOpenLights(int m, int n, char[,] grid)
    {
        var count = 0;
        for (var i = 0; i < m; i++)
        for (var j = 0; j < n; j++)
            if (grid[i, j] == '#')
                count += 1;
        return count;
    }
}