namespace AoC.Year2015.Day05;

public static class StringExtensions
{
    public static bool ContainsAtLeastThreeVowels(this string word)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        var count = word
            .Count(c => vowels.Contains(c));
        return count >= 3;
    }

    public static bool DoesntContainsBackListLetterGroups(this string word)
    {
        var backListGroup = new HashSet<string> { "ab", "cd", "pq", "xy" };
        return backListGroup.All(s => !word.Contains(s));
    }

    public static bool ContainsAtLeastOnceLetterTwice(this string word) =>
        Enumerable
            .Range(1, word.Length - 1)
            .Any(i => word[i - 1].Equals(word[i]));

    public static bool HasLetterWhichRepeatsWithExactlyOneLetterBetweenThem(this string word) =>
        Enumerable.Range(0, word.Length - 2)
            .Any(i => word[i + 2].Equals(word[i]));

    public static bool HasLetterPair(this string word) =>
        Enumerable.Range(0, word.Length - 1).Any(i =>
            word.IndexOf(word.Substring(i, 2), i + 2, StringComparison.Ordinal) >= 0);

}