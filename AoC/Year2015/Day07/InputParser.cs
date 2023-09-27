using System.Text.RegularExpressions;

namespace AoC.Year2015.Day07;

public static class InputParser
{
    public class State : Dictionary<string, int>
    {
    }

    public class Calc : Dictionary<string, Func<State, int>>
    {
    }

    public static Calc Parse(List<string> lines) =>
        lines.Aggregate(new Calc(), (calc, line) =>
            Gate(calc, line, @"(\w+) AND (\w+) -> (\w+)", pin => pin[0] & pin[1]) ??
            Gate(calc, line, @"(\w+) OR (\w+) -> (\w+)", pin => pin[0] | pin[1]) ??
            Gate(calc, line, @"(\w+) RSHIFT (\w+) -> (\w+)", pin => pin[0] >> pin[1]) ??
            Gate(calc, line, @"(\w+) LSHIFT (\w+) -> (\w+)", pin => pin[0] << pin[1]) ??
            Gate(calc, line, @"NOT (\w+) -> (\w+)", pin => ~pin[0]) ??
            Gate(calc, line, @"(\w+) -> (\w+)", pin => pin[0]) ??
            throw new Exception(line)
        );

    private static Calc? Gate(Calc? calc, string line, string pattern, Func<int[], int> op)
    {
        var match = Regex.Match(line, pattern);
        if (!match.Success)
        {
            return null;
        }

        var parts = match
            .Groups
            .Cast<Group>()
            .Skip(1)
            .Select(g => g.Value)
            .ToArray();

        var pinOut = parts.Last();
        var pins = parts.Take(parts.Length - 1).ToArray();

        if (calc == null)
        {
            throw new Exception("Null calc provided");
        }

        calc[pinOut] = state =>
        {
            if (state.TryGetValue(pinOut, out var expression)) return expression;
            var args = pins
                .Select(pin => int.TryParse(pin, out var i) ? i : calc[pin](state))
                .ToArray();

            state[pinOut] = op(args);
            return state[pinOut];
        };

        return calc;
    }
}