using System.Text;

namespace AoC.Year2015.Day10;

public class Problem
{
    public int Part1(string input)
    {
        var result = GenerateNewString(input, 40);
        return result.Length;
    }
    
    public int Part2(string input)
    {
        var result = GenerateNewString(input, 50);
        return result.Length;
    }

    private string GenerateNewString(string input, int count)
    {
        var testString = input;

        for (int i = 0; i < count; i++)
        {
            var newSequenceNumber = GenerateNewNumber(testString);
            testString = newSequenceNumber.ToString();
        }

        return testString;
    }

    private List<(char, int)> ParseNumber(string numberSequence)
    {
        if (string.IsNullOrEmpty(numberSequence))
        {
            throw new Exception("Illegal input");
        }

        var numbersOccurence = new List<(char, int)>();
        var count = 1;

        if (numberSequence.Length == 1)
        {
            numbersOccurence.Add((numberSequence[0], count));
            return numbersOccurence;
        }

        var numbers = numberSequence.ToCharArray();

        var i = 0;
        while (i < numbers.Length - 1)
        {
            if (numbers[i] == numbers[i + 1])
            {
                count += 1;
            }
            else
            {
                numbersOccurence.Add((numbers[i], count));
                count = 1;
            }

            i += 1;
        }

        numbersOccurence.Add((numbers[i], count));
        return numbersOccurence;
    }

    private StringBuilder GenerateNewNumber(string input)
    {
        var occurenceNumbers = ParseNumber(input);
        var sb = new StringBuilder();
        foreach (var pair in occurenceNumbers)
        {
            sb.Append($"{pair.Item2}{pair.Item1}");
        }

        return sb;
    }
}