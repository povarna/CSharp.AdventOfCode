namespace AoC.Year2015.Day11;

public static class PasswordValidator
{
    private static readonly List<char> BlackListedLetters = new() { 'i', 'o', 'l' };


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

        foreach (var letter in BlackListedLetters)
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

        var pairs = Enumerable.Range(0, password.Length - 1)
        .Select(i => password.Substring(i, 2))
        .Where(sword => sword[0] == sword[1])
        .Distinct();

        return pairs.Count() >1;

    }
}