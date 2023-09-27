namespace AoC.Year2015.Day06;

public class Problem
{
    public int Part1(string input)
    {
        var instructions = input.Split("\n").ToList().Parse();
        var grid = new int[1000, 1000];

        int SwitchFunc(LightAction lightAction, int currentVal) => lightAction switch
        {
            LightAction.turn_on => 1,
            LightAction.turn_off => -1,
            _ => currentVal == 1 ? -1 : 1
        };

        UpdateGrid(instructions, grid, SwitchFunc);

        int Func(int x) => x > 0 ? 1 : 0;
        return CalculateTotal(grid, Func);
    }

    public int Part2(string lines)
    {
        var instructions = lines.Split("\n").ToList().Parse();
        var grid = new int[1000, 1000];

        int SwitchFunc(LightAction lightAction, int currentVal) => lightAction switch
        {
            LightAction.turn_on => currentVal + 1,
            LightAction.turn_off => currentVal - 1 < 0 ? 0 : currentVal - 1,
            _ => currentVal + 2
        };

        UpdateGrid(instructions, grid, SwitchFunc);

        int Func(int x) => x > 0 ? x : 0;
        return CalculateTotal(grid, Func);
    }

    private static void UpdateGrid(List<Instruction> instructions, int[,] grid, Func<LightAction, int, int> switchFunc)
    {
        {
            foreach (var instruction in instructions)
            {
                for (var i = instruction.startPoint.x; i <= instruction.endPoint.x; i++)
                {
                    for (var j = instruction.startPoint.y; j <= instruction.endPoint.y; j++)
                    {
                        var currentVal = grid[i, j];
                        var newVal = switchFunc(instruction.action, currentVal);
                        grid[i, j] = newVal;
                    }
                }
            }
        }
    }

    private static int CalculateTotal(int[,] grid, Func<int, int> func)
    {
        var total = 0;
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                var currentValue = grid[i, j];
                total += func(currentValue);
            }
        }

        return total;
    }
}