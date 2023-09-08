namespace ConsoleApp.Year2015.Day05;

public class Problem
{
    public int Part1(List<string> input) =>
        input.Count(word =>
            word.ContainsAtLeastOnceLetterTwice() &&
            word.ContainsAtLeastThreeVowels() &&
            word.DoesntContainsBackListLetterGroups()
        );

    public int Part2(List<string> input) =>
        input.Count(word =>
            word.HasLetterWhichRepeatsWithExactlyOneLetterBetweenThem() &&
            word.HasLetterPair()
        );
}