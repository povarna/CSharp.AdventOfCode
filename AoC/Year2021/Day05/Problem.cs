using System.Text.RegularExpressions;
using AoC.Utils;

namespace AoC.Year2021.Day05;

public class Problem
{
    public int Part1(string input)
    {
        var instructions = ParseInput(input);
        var boardSize = instructions
            .Select(instruction => instruction.MaxCoordinate())
            .Max();
        var bord = new Board(boardSize);
        bord.UpdateGrid(instructions);
        return bord.CountOverlapPoints();
    }

    public int Part2(string input)
    {
        return -1;
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

        public void UpdateGrid(List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.From.Y == instruction.To.Y)
                {
                    var startPoint = Math.Min(instruction.From.X, instruction.To.X);
                    var endPoint = Math.Max(instruction.From.X, instruction.To.X);
                    for (var i = startPoint; i <= endPoint; i++)
                    {
                        _grid[instruction.From.Y, i] += 1;
                    }
                }
                else if (instruction.From.X == instruction.To.X)
                {
                    var startPoint = Math.Min(instruction.From.Y, instruction.To.Y);
                    var endPoint = Math.Max(instruction.From.Y, instruction.To.Y);
                    for (var j = startPoint; j <= endPoint; j++)
                    {
                        _grid[j, instruction.From.X] += 1;
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

        public void PrintGrid() => _grid.PrintGrid();
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