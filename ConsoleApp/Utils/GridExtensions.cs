namespace ConsoleApp.Utils;

public static class GridExtensions
{
    public static void PrintGrid(this int[,] grid)
    {
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j]);
            }

            Console.WriteLine();
        }
    }

    public static void PrintGrid(this int[][] grid)
    {
        foreach (var line in grid)
        {
            Console.WriteLine(string.Join("", line));
        }
    }

    public static (int m, int n) GetDimensions(this int[,] grid) => (grid.GetLength(0), grid.GetLength(1));
    
    public static (int m, int n) GetDimensions(this int[][] grid) => (grid.Length, grid[0].Length);

}