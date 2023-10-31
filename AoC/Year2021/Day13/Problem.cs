namespace AoC.Year2021.Day13;

public class Problem
{
    public int Part1(string input)
    {
        var points = GetPoints(input);
        var folds = GetFolds(input);

        var foldInstruction = folds.First();

        var newPoints =
            foldInstruction.direction == Direction.X
                ? FoldX(foldInstruction.coordinate, points)
                : FoldY(foldInstruction.coordinate, points);

        return newPoints.Count;
    }

    public int Part2(string input) => -1;

    private static HashSet<Point> FoldY(int y, HashSet<Point> points) =>
        points
            .Select(p => p.y > y ? new Point(x: p.x, y: 2 * y - p.y) : p)
            .ToHashSet();

    private static HashSet<Point> FoldX(int x, HashSet<Point> points) =>        
        points
            .Select(p => p.x > x ? new Point(x: 2 * x - p.x, y: p.y) : p)
            .ToHashSet();

    private static HashSet<Point> GetPoints(string input)
    {
        var blocks = input.Split("\r\n\r\n");
        return blocks[0].Split("\n")
            .Select(line => line.Trim())
            .Select(line => line.Split(","))
            .Select(arr => new Point(int.Parse(arr[0]), int.Parse(arr[1])))
            .ToHashSet();
    }

    private static List<Fold> GetFolds(string input)
    {
        var blocks = input.Split("\r\n\r\n");
        return blocks[1].Split("\n")
            .Select(line => line.Trim())
            .Select(line => line.Split("="))
            .Select(arr =>
                arr[0].EndsWith("x")
                    ? new Fold(int.Parse(arr[1]), Direction.X)
                    : new Fold(int.Parse(arr[1]), Direction.Y)
            )
            .ToList();
    }

    private record Point(int x, int y);

    private enum Direction
    {
        X,
        Y
    }

    private record Fold(int coordinate, Direction direction);
}