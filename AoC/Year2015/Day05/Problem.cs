namespace AoC.Year2015.Day05;

public class Problem
{
    public int Part1(string input) =>
        input.Split("\n")
            .Count(word =>
            word.ContainsAtLeastOnceLetterTwice() &&
            word.ContainsAtLeastThreeVowels() &&
            word.DoesntContainsBackListLetterGroups()
        );

    public int Part2(string input) =>
        input.Split("\n")
            .Count(word =>
            word.HasLetterWhichRepeatsWithExactlyOneLetterBetweenThem() &&
            word.HasLetterPair()
        );
}