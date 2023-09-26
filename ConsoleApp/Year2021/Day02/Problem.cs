namespace ConsoleApp.Year2021.Day02;

public class Problem
{
    public int Part1(string input)
    {
        var instructions = ParseInput(input).ToList();
        var position = Position.Initialize();
        
        foreach (var instruction in instructions)
        {
            position.MovePart1(instruction.Direction, instruction.Units);
        }
        
        return position.Horizontal * position.Depth;
    }

    public int Part2(string input)
    {
        var instructions = ParseInput(input).ToList();
        var position = Position.Initialize();
        
        foreach (var instruction in instructions)
        {
            position.MovePart2(instruction.Direction, instruction.Units);
        }
        
        return position.Horizontal * position.Depth;
    }

    private static IEnumerable<Instruction> ParseInput(string input) =>
        input.Split("\n")
            .Select(line => line.Split(" "))
            .Where(tokens => tokens.Length == 2)
            .Select(tokens =>
            {
                var units = int.Parse(tokens[1]);
                return tokens[0] switch
                {
                    "forward" => new Instruction(Direction.Forward, units),
                    "down" => new Instruction(Direction.Down, units),
                    "up" => new Instruction(Direction.Up, units),
                    _ => throw new ArgumentException("Invalid direction")
                };
            });
}

public enum Direction
{
    Forward,
    Down,
    Up
}

public sealed record Instruction(Direction Direction, int Units);

public sealed class Position
{
    private Position(int horizontal, int depth, int aim)
    {
        Horizontal = horizontal;
        Depth = depth;
        Aim = aim;
    }

    public static Position Initialize() => new(0, 0, 0);

    public int Horizontal { get; private set; }
    public int Depth { get; private set; }
    private int Aim { get; set; }
    
    public void MovePart1(Direction direction, int unit)
    {
        switch (direction)
        {
            case Direction.Forward:
                Horizontal += unit;
                break;
            case Direction.Down:
                Depth += unit;
                break;
            case Direction.Up:
                Depth -= unit;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, "Invalid direction");
        }
    }
    
    public void MovePart2(Direction direction, int unit)
    {
        switch (direction)
        {
            case Direction.Forward:
                Horizontal += unit;
                Depth += Aim * unit;
                break;
            case Direction.Down:
                Aim += unit;
                break;
            case Direction.Up:
                Aim -= unit;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, "Invalid direction");
        }
    }
} 