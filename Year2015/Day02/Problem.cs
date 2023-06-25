namespace Year2015.Day02;

public class Problem
{
    public int Part1(string input)
    {
        return GetBoxesDimensions(input)
            .Select(box => box.GetPart1Dimensions())
            .Sum();
    }

    public int Part2(string input)
    {
        return GetBoxesDimensions(input)
            .Select(box => box.GetPart2Dimensions())
            .Sum();
    }
    
    private IEnumerable<Box> GetBoxesDimensions(string input)
    {
        return input.Split("\n")
            .Select(BuildBox);
    }
    
    private Box BuildBox(string line)
    {
        var dimensions =  line.Split("x")
            .Select(int.Parse)
            .OrderBy(x => x)
            .ToArray();
        return new Box(dimensions[0], dimensions[1], dimensions[2]);
    }
}

public class Box
{
    private readonly int _l;
    private readonly int _w;
    private readonly int _h;

    public Box(int l, int w, int h)
    {
        _l = l;
        _w = w;
        _h = h;
    }

    public int GetPart1Dimensions() => 2 * (_l * _w + _w * _h + _h * _l) + _l * _w;
    public int GetPart2Dimensions() => _l * _w * _h + 2 * (_l + _w);

}