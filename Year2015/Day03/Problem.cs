namespace Year2015.Day03;

public class Problem
{
    public int Part1(string input)
    {
        var visited = new HashSet<(int, int)> { (0, 0) };
        (int irow, int icol) currentPosition = (0, 0);
        foreach (var ch in input)
        {
            switch (ch)
            {
                case '^': currentPosition.irow-- ; break;
                case '<': currentPosition.icol--; break;
                case '>': currentPosition.icol++; break;
                case 'v': currentPosition.irow++; break;
            }
            visited.Add(currentPosition);
        }
        return visited.Count;
    }

    public int Part2(string input)
    {
        return -1;
    }
    
}