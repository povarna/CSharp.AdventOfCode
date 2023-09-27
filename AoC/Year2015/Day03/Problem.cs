namespace AoC.Year2015.Day03;

public class Problem
{
    public int Part1(string input) => VisitedCount(input, 1);
    
    public int Part2(string input) => VisitedCount(input, 2);

    private int VisitedCount(string input, int actors)
    {
        var visited = new HashSet<(int, int)> { (0, 0) };
        var positions = new (int irow, int icol)[actors];
        for (var i = 0; i < actors; i++)
        {
            positions[i] = (0, 0);
        }

        int actor = 0;
        foreach (var t in input)
        {
            var newPosition = GetNewPosition(t, positions[actor]);
            visited.Add(newPosition);
            positions[actor] = newPosition;
            actor = (actor + 1) % actors;
        }

        return visited.Count;
    }

    private (int, int) GetNewPosition(char ch, (int irow, int icol) position)
    {
        switch (ch)
        {
            case '^':
                position.irow--;
                break;
            case '<':
                position.icol--;
                break;
            case '>':
                position.icol++;
                break;
            case 'v':
                position.irow++;
                break;
        }

        return position;
    }
}