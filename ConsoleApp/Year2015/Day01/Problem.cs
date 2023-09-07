namespace ConsoleApp.Year2015.Day01;

public class Problem
{
    public int Part1(string input) => Levels(input).Last().level;

    public int Part2(string input) => Levels(input).First(p => p.level == -1).idx;

    private IEnumerable<(int idx, int level)> Levels(string input)
    {
        var level = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var value = input[i] == '(' ? 1 : -1;
            level += value;
            yield return (i + 1, level);
        }
    }

}