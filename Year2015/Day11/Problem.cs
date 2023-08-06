namespace Year2015.Day11;
public class Problem
{

    public int Part1(string input)
    {
        Console.WriteLine(input.IsPasswordValid());
        return -1;
    }

    public int Part2(string input)
    {
        return -1;
    }

}

public static class PasswordValidator
{
    private static readonly List<Char> _blackListedLetters = new() { 'i', 'o', 'l' };


    public static bool IsPasswordValid(this string password)
    {
        return password.HasIncreasingStraightLetters() && password.IsWithoutBlacklistedLetters() && password.HasAtLeastTwoNonOverlappingPairs();
    }

    private static bool HasIncreasingStraightLetters(this string password)
    {
        if (password.Length < 3)
        {
            return false;
        }

        var passwordChars = password.ToCharArray();

        for (var i = 0; i < passwordChars.Length - 2; i++)
        {
            if (passwordChars[i + 2] - passwordChars[i + 1] == 1 && passwordChars[i + 1] - passwordChars[i] == 1)
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsWithoutBlacklistedLetters(this string password)
    {

        foreach (var letter in _blackListedLetters)
        {
            if (password.Contains(letter))
            {
                return false;
            }
        }
        return true;
    }

    private static bool HasAtLeastTwoNonOverlappingPairs(this string password)
    {
        if (password.Length < 4)
        {
            return false;
        }

        var passwordChars = password.ToCharArray();
        var count = 0;
        for (var i = 0; i < passwordChars.Length - 2; i++)
        {
            if (passwordChars[i] == passwordChars[i + 1])
            {
                count += 1;
                if (count == 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
}