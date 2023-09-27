namespace AoC.Year2015.Day23;

public class Problem
{
    public long Part1(string input) => Solve(input, 0);
    public long Part2(string input) => Solve(input, 1);

    private static long Solve(string input, long a)
    {
        var registry = new Dictionary<string, long>();

        void SetRegistry(string reg, long value)
        {
            registry[reg] = value;
        }

        long GetRegistry(string reg)
        {
            return long.TryParse(reg, out var n) ? n
                : registry.TryGetValue(reg, out var value) ? value
                : 0;
        }

        SetRegistry("a", a);
        var instructions = input.Split('\n');
        var i = 0L;

        while (i >= 0 && i < instructions.Length)
        {
            var line = instructions[i].Trim();
            var parts = line.Replace(",", "").Split(" ");
            switch (parts[0])
            {
                case "hlf":
                    SetRegistry(parts[1], GetRegistry(parts[1]) / 2);
                    i++;
                    break;
                case "tpl":
                    SetRegistry(parts[1], GetRegistry(parts[1]) * 3);
                    i++;
                    break;
                case "inc":
                    SetRegistry(parts[1], GetRegistry(parts[1]) + 1);
                    i++;
                    break;
                case "jmp":
                    i += GetRegistry(parts[1]);
                    break;
                case "jie":
                    i += GetRegistry(parts[1]) % 2 == 0 ? GetRegistry(parts[2]) : 1;
                    break;
                case "jio":
                    i += GetRegistry(parts[1]) == 1 ? GetRegistry(parts[2]) : 1;
                    break;
                default: throw new Exception("Cannot parse " + line);
            }
        }

        return GetRegistry("b");
    }
}