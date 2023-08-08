using System.Text.Json;

namespace Year2015.Day12;

public class Problem
{
    public int Part1(string input)
    {
        return Solve(input, false);
    }

    public int Part2(string input)
    {
        return Solve(input, true);
    }

    private int Solve(string input, bool skipRed)
    {
        int Traverse(JsonElement jsonElement)
        {
            return jsonElement.ValueKind switch
            {
                JsonValueKind.Object when skipRed && jsonElement.EnumerateObject().Any(t =>
                    t.Value.ValueKind == JsonValueKind.String && t.Value.GetString() == "red") => 0,
                JsonValueKind.Object => jsonElement.EnumerateObject().Select(t => Traverse(t.Value)).Sum(),
                JsonValueKind.Array => jsonElement.EnumerateArray().Select(Traverse).Sum(),
                JsonValueKind.Number => jsonElement.GetInt32(),
                _ => 0
            };
        }

        return Traverse(JsonDocument.Parse(input).RootElement);
    }
}