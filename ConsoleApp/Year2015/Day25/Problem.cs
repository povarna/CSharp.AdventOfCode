using System.Text.RegularExpressions;

namespace ConsoleApp.Year2015.Day25;

public class Problem
{
    public object Part1(string input) {
        var m = 20151125L;
        var (irow, icol) = (1, 1);
        var (irowDst, icolDst) = Parse(input);
        while (irow != irowDst || icol != icolDst) {
            irow--;
            icol++;
            if (irow == 0) {
                irow = icol;
                icol = 1;
            }
            m = (m * 252533L) % 33554393L;
        }
        return m;
    }

    private static (int irowDst, int icolDist) Parse(string input)
    {
        var m = Regex.Match(input,
            @"To continue, please consult the code grid in the manual.  Enter the code at row (\d+), column (\d+).");
        return (int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value));
    }
}