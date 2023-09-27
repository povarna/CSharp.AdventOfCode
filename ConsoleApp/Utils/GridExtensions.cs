namespace ConsoleApp.Utils;

public static class GridExtensions
{
    public static void PrintGrind(this int[,] grid)
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

    public static (int m, int n) GetDimensions(this int[,] grid) => (grid.GetLength(0), grid.GetLength(1));
}