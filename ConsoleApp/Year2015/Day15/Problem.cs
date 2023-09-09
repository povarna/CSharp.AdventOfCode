using System.Text.RegularExpressions;

namespace ConsoleApp.Year2015.Day15;

public class Problem
{
    public int Part1(string input)
    {
        var ingredientsProperties = input.Split("\n")
            .Select(CreateIngredientsProperties)
            .ToList();

        return MixIngredients(ingredientsProperties, null).ToArray().Max();
    }

    public int Part2(string input)
    {
        var ingredientsProperties = input.Split("\n")
            .Select(CreateIngredientsProperties)
            .ToList();

        return MixIngredients(ingredientsProperties, 500).ToArray().Max();
    }

    private static int[] CreateIngredientsProperties(string line)
    {
        var regex =
            Regex.Match(
                input: line,
                pattern: @"(.*): capacity (.*), durability (.*), flavor (.*), texture (.*), calories (.*)"
            );
        if (regex.Groups.Count != 7)
        {
            throw new ArgumentException($"Invalid input. Can't parse the input line: {line}");
        }

        return regex.Groups.Cast<Group>()
            .Skip(2)
            .Select(g => int.Parse(g.Value))
            .ToArray();
    }

    private static IEnumerable<int> MixIngredients(IReadOnlyList<int[]> ingredientsPropertiesList, int? calories)
    {
        const int amountOfIngredients = 100;
        List<int> ingredientsWeight = new();

        var numberOfIngredients = ingredientsPropertiesList.Count;
        var numberOfProperties = ingredientsPropertiesList[0].Length;

        foreach (var partition in Partition(amountOfIngredients, numberOfIngredients))
        {
            var partitionLength = partition.Length;
            var propsArray = new int[partitionLength, numberOfProperties];

            for (var i = 0; i < partitionLength; i++)
            {
                var currentIngredient = ingredientsPropertiesList[i];
                var count = partition[i];
                for (var j = 0; j < currentIngredient.Length; j++)
                {
                    propsArray[i, j] += currentIngredient[j] * count;
                }
            }

            var totalScores = CalculateTotalScore(numberOfProperties, partitionLength, propsArray);

            if (calories.HasValue && totalScores.Last() != calories.Value) continue;

            var totalScore = CalculateTotalScore(totalScores);
            if (totalScore > 0) ingredientsWeight.Add(totalScore);
        }

        return ingredientsWeight;
    }

    private static int CalculateTotalScore(IEnumerable<int> totalScores)
    {
        return totalScores
            .SkipLast(1)
            .ToArray()
            .Aggregate(1, (current, a) => current * (a < 0 ? 0 : a));
    }

    private static int[] CalculateTotalScore(int numberOfProperties, int partitionLength, int[,] propsArray)
    {
        var accArray = new int[numberOfProperties];
        for (var t = 0; t < numberOfProperties; t++)
        {
            for (var p = 0; p < partitionLength; p++)
            {
                accArray[t] += propsArray[p, t];
            }
        }

        return accArray;
    }

    private static IEnumerable<int[]> Partition(int n, int k)
    {
        if (k == 1)
        {
            yield return new[] { n };
        }
        else
        {
            for (var i = 0; i <= n; i++)
            {
                foreach (var rest in Partition(n - i, k - 1))
                {
                    yield return rest.Append(i).ToArray();
                }
            }
        }
    }

    private static IEnumerable<int[]> Distribute4(int max)
    {
        for (var a = 0; a <= max; a++)
        for (var b = 0; b <= max - a; b++)
        for (var c = 0; c <= max - a - b; c++)
            yield return new[] { a, b, c, max - a - b - b };
    }
}