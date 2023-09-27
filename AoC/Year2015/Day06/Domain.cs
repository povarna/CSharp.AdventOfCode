namespace AoC.Year2015.Day06;

public record Point(int x, int y);

public enum LightAction
{
    turn_on,
    turn_off,
    toggle
}

public record Instruction(Point startPoint, Point endPoint, LightAction action);