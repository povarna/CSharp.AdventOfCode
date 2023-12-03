using System.Text.RegularExpressions;

namespace AoC.Year2023.Day03;
public class Problem
{
    public int Part1(string input) {
        var rows = input.Split("\n");
        var symbols = Parse(rows, new Regex(@"[^.0-9]"));
        var nums = Parse(rows, new Regex(@"\d+"));

        foreach (var num in nums)
        {
            Console.WriteLine(num);
        }

        foreach(var symbol in symbols) {
            Console.WriteLine(symbol);
        }

        return (
            from n in nums
            where symbols.Any(s => NextTo(s, n))
            select n.Int
        ).Sum();
    }

    public int Part2(string input) {
        var rows = input.Split("\n");
        var gears = Parse(rows, new Regex(@"\*"));
        var numbers = Parse(rows, new Regex(@"\d+"));

        return (
            from g in gears
            let neighbours = from n in numbers where NextTo(n, g) select n.Int
            where neighbours.Count() == 2
            select neighbours.First() * neighbours.Last()
        ).Sum();
    }

    // checks that the parts are touching each other, i.e. rows are within 1 
    // step and also the columns (using https://stackoverflow.com/a/3269471).
    bool NextTo(Part p1, Part p2) => 
        Math.Abs(p2.Irow - p1.Irow) <= 1 &&
        p1.Icol <= p2.Icol + p2.Text.Length &&
        p2.Icol <= p1.Icol + p1.Text.Length;

    // returns the matches of rx with its coordinates
    Part[] Parse(string[] rows, Regex rx) => (
        from irow in Enumerable.Range(0, rows.Length)
        from match in rx.Matches(rows[irow])
        select new Part(match.Value, irow, match.Index)
    ).ToArray();
}

record Part(string Text, int Irow, int Icol) {
    public int Int => int.Parse(Text);

    public override string ToString()
    {
        return $"Part[x: {Text}, Irow: {Irow}, Icol: {Icol}]";
    }
}
