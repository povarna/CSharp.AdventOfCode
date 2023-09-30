namespace AoC.Year2021.Day06;

public class Problem
{
    public long Part1(string input) => GetTheNumberOfLanternFish(input, 80);
    public long Part2(string input) => GetTheNumberOfLanternFish(input, 256);

    private static long GetTheNumberOfLanternFish(string input, int days)
    {
        var ages = ParseInput(input);
        var occurrence = new Dictionary<int, long>();
        occurrence.Initialize();

        foreach (var age in ages)
        {
            occurrence[age] += 1;
        }

        foreach (var _ in Enumerable.Range(0, days))
        {
            var newOccurrenceDict = new Dictionary<int, long>();
            newOccurrenceDict.Initialize();

            foreach (var key in occurrence.Select(entry => entry.Key))
            {
                if (key == 0)
                {
                    newOccurrenceDict[6] += occurrence[key];
                    newOccurrenceDict[8] = occurrence[key];
                }
                else
                {
                    newOccurrenceDict[key - 1] += occurrence[key];
                }
            }

            occurrence = newOccurrenceDict;
        }

        return occurrence.Sum(entry => occurrence[entry.Key]);
    }

    private static IEnumerable<int> ParseInput(string input) => input.Split(",")
        .Select(n => n.Trim())
        .Select(int.Parse)
        .ToArray();

    // Dummy solution. Run OutOfMemory for a large number of days
    private static long FishCountAfterNDays(string input, int numberOfIterations)
    {
        var ages = ParseInput(input);

        var queue = new Queue<long>();
        foreach (var age in ages)
        {
            queue.Enqueue(age);
        }

        var i = 0;
        while (i < numberOfIterations)
        {
            var queueLenght = queue.Count;
            foreach (var _ in Enumerable.Range(0, queueLenght))
            {
                var t = queue.Dequeue();
                if (t - 1 < 0)
                {
                    queue.Enqueue(6);
                    queue.Enqueue(8);
                }
                else
                {
                    queue.Enqueue(t - 1);
                }
            }

            i += 1;
        }

        return queue.Count;
    }
}

internal static class DictionaryExtension
{
    public static void Initialize(this Dictionary<int, long> dict)
    {
        foreach (var i in Enumerable.Range(0, 9))
            dict[i] = 0;
    }
}