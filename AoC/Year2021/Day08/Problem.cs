namespace AoC.Year2021.Day08;

public class Problem
{
    public int Part1(string input)
    {
        var validLengthPatterns = new HashSet<int> { 2, 3, 4, 7 };
        return input.Split("\n")
            .Select(line => line.Split("|"))
            .Select(parts => parts[1])
            .Select(patterns => patterns.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .SelectMany(x => x)
            .Select(pattern => pattern.Trim())
            .Count(pattern => validLengthPatterns.Contains(pattern.Length));
    }

    public int Part2(string input) => 
        input
            .Split("\n")
            .Select(s => s.Trim())
            .Sum(SolveRow);

    private static int SolveRow(string input)
    {
        var data = input.Split(" | ");

        var hints = data[0].Split(" ");
        var number = data[1].Split(" ");

        var cHints = hints.Select(x => x.ToCharArray().ToHashSet());
        var cNumber = number.Select(x => x.ToCharArray().ToHashSet()).ToArray();

        var decrypt = new HashSet<char>[10];
        decrypt[1] = cHints.FirstOrDefault(x => x.Count == 2);
        decrypt[4] = cHints.FirstOrDefault(x => x.Count == 4);
        decrypt[7] = cHints.FirstOrDefault(x => x.Count == 3);
        decrypt[8] = cHints.FirstOrDefault(x => x.Count == 7);
        
        var tmp5 = cHints.Where(x => x.Count == 5);
        var tmp6 = cHints.Where(x => x.Count == 6);
        
        foreach (var a in tmp5)
        {
            var b = new HashSet<char>();
            b.UnionWith(a.ToList());
            b.ExceptWith(decrypt[7]);
            if (b.Count == 2)
            {
                decrypt[3] = a;
            }
        }

        foreach (var a in tmp6)
        {
            var b = new HashSet<char>();
            b.UnionWith(a.ToList());
            b.ExceptWith(decrypt[7]);
            if (b.Count == 4)
            {
                decrypt[6] = a;
            }
        }

        tmp5 = tmp5.Where(x => !x.SetEquals(decrypt[3]));
        tmp6 = tmp6.Where(x => !x.SetEquals(decrypt[6]));
        foreach (var a in tmp5)
        {
            var b = new HashSet<char>();
            b.UnionWith(a.ToList());
            b.ExceptWith(decrypt[3]);
            b.ExceptWith(decrypt[4]);
            switch (b.Count)
            {
                case 1:
                    decrypt[2] = a;
                    break;
                case 0:
                    decrypt[5] = a;
                    break;
            }
        }

        foreach (var a in tmp6)
        {
            var b = new HashSet<char>();
            b.UnionWith(a.ToList());
            b.ExceptWith(decrypt[3]);
            switch (b.Count)
            {
                case 2:
                    decrypt[0] = a;
                    break;
                case 1:
                    decrypt[9] = a;
                    break;
            }
        }

        var resultDigits = new int[4];
        for (var i = 0; i < resultDigits.Length; i++)
        {
            for (var j = 0; j < decrypt.Length; j++)
            {
                if (!cNumber[i].SetEquals(decrypt[j])) continue;
                resultDigits[i] = j;
                break;
            }
        }

        return resultDigits[0] * 1000 + resultDigits[1] * 100 + resultDigits[2] * 10 + resultDigits[3];
    }
}