namespace ConsoleApp.Year2016.Day01;

public class Problem
{
    public int Part1(string input)
    {
        var instructions = ParseInput(input);
        return GridWalk(instructions);
    }
    
    public int Part2(string input)
    {
        var instructions = ParseInput(input);
        return GridWalk(instructions, true);
    }

    private static IEnumerable<string> ParseInput(string input) => input.Split(", ").ToArray();

    private static int GridWalk(IEnumerable<string> instructions, bool uniqueDirections = false)
    {
        var (x, y) = (0, 0);
        var orientation = 0;
        var visited = new HashSet<(int, int)> { (0, 0) };

        foreach (var instruction in instructions)
        {
            var chars = instruction.ToCharArray();
            var turn = chars[0];
            var steps = int.Parse(chars.AsSpan()[1..]);
            orientation = (orientation < 0) ? orientation + 4 : orientation;
            orientation = turn == 'R' ? (orientation + 1) % 4 : (orientation - 1) % 4;

            for (var i = 0; i < steps; i++)
            {
                switch (orientation)
                {
                    case 0:
                        y += 1;
                        break;
                    case 1:
                        x += 1;
                        break;
                    case 2:
                        y -= 1;
                        break;
                    default:
                        x -= 1;
                        break;
                }

                if (uniqueDirections)
                {
                    if (visited.Contains((x, y)))
                    {
                        return Math.Abs(x) + Math.Abs(y);
                    }

                    visited.Add((x, y));
                }
            }
        }

        return Math.Abs(x) + Math.Abs(y);
    }
}