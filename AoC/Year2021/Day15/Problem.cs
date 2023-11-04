using System.Drawing;
using System.Runtime.CompilerServices;

namespace AoC.Year2021.Day15;

public class Problem
{
    public int Part1(string input) => CalculateRisk(ParseInput(input));

    public int Part2(string input) => CalculateRisk(ScaleUp(ParseInput(input)));
    

    private static int CalculateRisk(Dictionary<Point, int> coordinates)
    {
        var topLeft = new Point(0, 0);
        var bottomRight = new Point(coordinates.Keys.MaxBy(p => p.X).X, coordinates.Keys.MaxBy(p => p.Y).Y);

        var totalRiskMap = new Dictionary<Point, int>();
        var queue = new PriorityQueue<Point, int>();

        totalRiskMap[topLeft] = 0;
        queue.Enqueue(topLeft, 0);

        while (true)
        {
            var p = queue.Dequeue();
            if (p == bottomRight)
            {
                break;
            }

            foreach (var v in GetNeighbors(p))
            {
                if (coordinates.ContainsKey(v))
                {
                    var totalRiskScoreP = totalRiskMap[p] + coordinates[v];
                    if (totalRiskScoreP < totalRiskMap.GetValueOrDefault(v, int.MaxValue))
                    {
                        totalRiskMap[v] = totalRiskScoreP;
                        queue.Enqueue(v, totalRiskScoreP);
                    }
                }
            }
        }

        return totalRiskMap[bottomRight];
    }

    private static Dictionary<Point, int> ParseInput(string input)
    {
        var lines = input.Split(Utils.Constants.EOL);
        var m = lines.Length;
        var n = lines[0].Length;

        var coordinates = new Dictionary<Point, int>();

        for (var i = 0; i < m; i++)
        {
            var currentLine = lines[i];
            for (int j = 0; j < n; j++)
            {
                coordinates.Add(new Point(i, j), currentLine[j] - '0');
            }
        }

        return coordinates;
    }


    private static Dictionary<Point, int> ScaleUp(Dictionary<Point, int> map ) {
        var (ccol, crow) = (map.Keys.MaxBy(p => p.X).X + 1, map.Keys.MaxBy(p => p.Y).Y + 1);

        var totalRiskMap = new Dictionary<Point, int>();
        for (var y = 0 ; y< crow * 5; y++) {
            for (var x = 0; x < ccol * 5; x++) {
                var tileY  = y % crow;
                var tileX = x % ccol;

                var riskLevel = map[new Point(tileX, tileY)];
                var pointDistance = (y / crow) + (x / ccol);

                var newRiskLevel = (riskLevel + pointDistance - 1) % 9 + 1;
                totalRiskMap.Add(new Point(x,y), newRiskLevel);
            }
        }
        return totalRiskMap;
    }

    private static Point[] GetNeighbors(Point point) => new Point[] {
        new(point.X - 1, point.Y),
        new(point.X + 1, point.Y),
        new(point.X, point.Y - 1),
        new(point.X, point.Y + 1)
        };
    private record Point(int X, int Y);

}