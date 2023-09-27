namespace AoC.Year2015.Day06;

public static class InputParser
{
    private const string ComaSeparator = ",";
    private const string DashSeparator = "_";
    private const string SpaceSeparator = " ";

    public static List<Instruction> Parse(this List<string> lines)
    {
        var instructions = new List<Instruction>();

        foreach (var line in lines)
        {
            var turnOnValue = LightAction.turn_on.ToString().Replace(DashSeparator, SpaceSeparator);
            var turnOffValue = LightAction.turn_off.ToString().Replace(DashSeparator, SpaceSeparator);
            var tokens = line.Split(SpaceSeparator);

            Instruction instruction;

            if (line.StartsWith(turnOnValue) || line.StartsWith(turnOffValue))
            {
                var point1 = tokens[2].Split(ComaSeparator).Select(int.Parse).ToArray();
                var point2 = tokens[4].Split(ComaSeparator).Select(int.Parse).ToArray();
                if (line.StartsWith(turnOnValue))
                {
                    instruction = new Instruction(
                        startPoint: new Point(point1[0], point1[1]),
                        endPoint: new Point(point2[0], point2[1]),
                        action: LightAction.turn_on);
                }
                else
                {
                    instruction = new Instruction(
                        startPoint: new Point(point1[0], point1[1]),
                        endPoint: new Point(point2[0], point2[1]),
                        action: LightAction.turn_off);
                }
            }
            else
            {
                var point1 = tokens[1].Split(ComaSeparator).Select(int.Parse).ToArray();
                var point2 = tokens[3].Split(ComaSeparator).Select(int.Parse).ToArray();
                instruction = new Instruction(
                    startPoint: new Point(point1[0], point1[1]),
                    endPoint: new Point(point2[0], point2[1]),
                    action: LightAction.toggle);
            }

            instructions.Add(instruction);
        }

        return instructions;
    }
}