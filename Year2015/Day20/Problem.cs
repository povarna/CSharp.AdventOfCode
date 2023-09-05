namespace Year2015.Day20;

public class Problem
{
    public int Part1(string input)
    {
        var l = int.Parse(input);
        return PresentsByHouse(1_000_000, 10, l);
    }

    
    public int Part2(string input)
    {
        var l = int.Parse(input);
        return PresentsByHouse(50, 11, l);
    }
    
    private static int PresentsByHouse(int steps, int mul, int l)
    {
        var presents = new int[1_000_000];
        for (var i = 1; i < presents.Length; i++)
        {
            var j = i;
            var step = 0;
            while (j < presents.Length && step < steps)
            {
                presents[j] += mul * i;
                j += i;
                step++;
            }
        }

        for (var i = 0; i < presents.Length; i++)
        {
            if (presents[i] >= l)
            {
                return i;
            }
        }

        return -1;
    }

}