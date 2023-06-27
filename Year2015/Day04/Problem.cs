namespace Year2015.Day04;

public class Problem
{
    public int Part1(string input)
    {
        return GetIntegerWhichGiveMd5HashWithPrefix(input, 5);
    }
    
    public int Part2(string input)
    {
        return GetIntegerWhichGiveMd5HashWithPrefix(input, 6);
    }


    private int GetIntegerWhichGiveMd5HashWithPrefix(string input, int numberOfZeros)
    {
        var startString = new string('0', numberOfZeros);
        var integerWhichGiveMd5HashWithPrefix = 0;
        Parallel.ForEach(Enumerable.Range(0, int.MaxValue), (i, state) =>
        {
            var word = $"{input}{i}";
            var encodedWord = word.MD5Encode();
            if (encodedWord.StartsWith(startString))
            {
                integerWhichGiveMd5HashWithPrefix = i;
                state.Stop();
            }
        });
        return integerWhichGiveMd5HashWithPrefix;
    }
}