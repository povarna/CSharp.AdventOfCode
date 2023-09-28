using System.Text.RegularExpressions;

namespace AoC.Year2021.Day05;

public class Problem
{
    public int Part1(string input) => GetBoard(input).CountOverlapPoints();

    public int Part2(string input) => GetBoard(input, true).CountOverlapPoints();

    private static Board GetBoard(string input, bool withDiagonals = false)
    {
        var instructions = ParseInput(input);
        var boardSize = instructions
            .Select(instruction => instruction.MaxCoordinate())
            .Max();
        var bord = new Board(boardSize + 1);
        bord.UpdateGrid(instructions, withDiagonals);
        return bord;
    }

    private static List<Instruction> ParseInput(string input) =>
        input.Split("\n")
            .Select(line => Regex.Match(line, @"(.*),(.*) -> (.*),(.*)"))
            .Where(matches => matches.Length != 5)
            .Select(match => new Instruction(
                From: new Coordinate(
                    X: int.Parse(match.Groups[1].Value),
                    Y: int.Parse(match.Groups[2].Value)),
                To: new Coordinate(
                    X: int.Parse(match.Groups[3].Value),
                    Y: int.Parse(match.Groups[4].Value)))
            )
            .ToList();

    private sealed class Board
    {
        private readonly int[,] _grid;
        private readonly int _size;

        public Board(int size)
        {
            _size = size;
            _grid = new int[size, size];
        }

        public void UpdateGrid(List<Instruction> instructions, bool withDiagonals = false)
        {
            foreach (var instruction in instructions)
            {
                var fromX = instruction.From.X;
                var toX = instruction.To.X;
                var fromY = instruction.From.Y;
                var toY = instruction.To.Y;

                //Case: 0,9 -> 5,9
                if (fromY == toY)
                {
                    var startPoint = Math.Min(fromX, toX);
                    var endPoint = Math.Max(fromX, toX);
                    for (var i = startPoint; i <= endPoint; i++)
                    {
                        _grid[fromY, i] += 1;
                    }
                }
                //Case: 2,2 -> 2,1
                else if (fromX == toX)
                {
                    var startPoint = Math.Min(fromY, toY);
                    var endPoint = Math.Max(fromY, toY);
                    for (var i = startPoint; i <= endPoint; i++)
                    {
                        _grid[i, fromX] += 1;
                    }
                }

                if (!withDiagonals) continue;
                //Case: 8,0 -> 0,8
                if (fromX == fromY && toX == toY)
                {
                    var startPoint = Math.Min(fromX, toX);
                    var endPoint = Math.Max(fromX, toX);
                    for (var i = startPoint; i <= endPoint; i++)
                    {
                        _grid[i, i] += 1;
                    }
                }
                //Case: 0,0 -> 8,8
                else if (fromX == toY && fromY == toX)
                {
                    var startPoint = Math.Min(fromX, fromY);
                    var endPoint = Math.Max(toX, toY);
                    var diff = endPoint - startPoint;
                    for (var i = 0; i <= diff; i++)
                    {
                        _grid[startPoint + i, endPoint - i] += 1;
                    }
                }
                //Case: 5,5 -> 8,2
                else if (fromX > toX && fromY < toY || fromX < toX && fromY > toY)
                {
                    var x = Math.Max(fromX, toX);
                    var y = Math.Min(fromY, toY);
                    var diff = Math.Abs(fromX - toX);
                    for (var i = 0; i <= diff; i++)
                    {
                        _grid[y + i, x - i] += 1;
                    }
                }
                // Case: 6,4 -> 2,0
                else if (fromX > toX && fromY > toY || fromX < toX && fromY < toY)
                {
                    var y = Math.Min(fromX, toX);
                    var x = Math.Min(fromY, toY);

                    var diff = Math.Abs(fromX - toX);
                    for (var i = 0; i <= diff; i++)
                    {
                        _grid[x + i, y + i] += 1;
                    }
                }
            }
        }

        public int CountOverlapPoints()
        {
            var total = 0;
            for (var i = 0; i < _size; i++)
            for (var j = 0; j < _size; j++)
                total += (_grid[i, j] > 1) ? 1 : 0;
            return total;
        }
    }

    private sealed record Coordinate(int X, int Y)
    {
        public override string ToString() => $"[{X}, {Y}]";
    }

    private sealed record Instruction(Coordinate From, Coordinate To)
    {
        public int MaxCoordinate() => Math.Max(Math.Max(From.X, From.Y), Math.Max(To.X, To.Y));

        public override string ToString() => $"{From} -> {To}";
    }
}