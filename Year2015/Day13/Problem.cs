
using System.Text.RegularExpressions;

namespace Year2015.Day13;

public class Problem
{
    public object Part1(string input) => Happiness(input, false).Max();
    public object Part2(string input) => Happiness(input, true).Max();


    IEnumerable<int> Happiness(string input, bool includeMe)
    {

        var dict = new Dictionary<(string, string), int>();
        foreach (var line in input.Split('\n'))
        {
            var m = Regex.Match(line, @"(.*) would (.*) (.*) happiness units by sitting next to (.*).");
            var a = m.Groups[1].Value;
            var b = m.Groups[4].Value;
            var happiness = int.Parse(m.Groups[3].Value) * (m.Groups[2].Value == "gain" ? 1 : -1);
            if (!dict.ContainsKey((a, b)))
            {
                dict[(a, b)] = 0;
                dict[(b, a)] = 0;
            }
            dict[(a, b)] += happiness;
            dict[(b, a)] += happiness;
        }

        var people = dict.Keys
        .Select(k => k.Item1)
        .Distinct()
        .ToList();

        if (includeMe)
        {
            people.Add("me");
        }

        // TODO: replace this with classic for loops
        var permutations = Permutations(people.ToArray())
            .Select(order =>
                order.Zip(order.Skip(1).Append(order[0]), (a, b) => (a, b)).ToArray()
        );

        var sums = new List<int>();
        foreach (var pair in permutations)
        {
            var sum = 0;
            foreach (var p in pair)
            {
                sum += dict.TryGetValue(p, out var v) ? v : 0;
            }
            // System.Console.WriteLine(String.Join(",", pair));
            // System.Console.WriteLine(sum);
            // System.Console.WriteLine("---------");
            sums.Add(sum);
        }

        return sums;
    }

    public IEnumerable<string[]> Permutations(string[] rgt)
    {
        IEnumerable<string[]> PermutationRec(int i)
        {

            if (i == rgt.Length)
            {
                yield return rgt.ToArray();
            }

            for (var j = i; j < rgt.Length; j++)
            {
                (rgt[i], rgt[j]) = (rgt[j], rgt[i]);
                foreach (var perm in PermutationRec(i + 1))
                {
                    yield return perm;
                }
                (rgt[i], rgt[j]) = (rgt[j], rgt[i]);
            }

        }
        return PermutationRec(0);
    }

}
