namespace ConsoleApp.Year2021.Day04;

public class Problem
{
    public int Part1(string input) => GetCompletionBoards(input).First().Score;
    public int Part2(string input) => GetCompletionBoards(input).Last().Score;

    private static IEnumerable<BingoBoard> GetCompletionBoards(string input)
    {
        // Split by empty line
        var blocks = input.Split("\r\n\r\n");

        var numbers = blocks[0].Split(",");
        var boards = blocks.Skip(1)
            .Select(block => new BingoBoard(block))
            .ToHashSet();

        foreach (var number in numbers)
        {
            foreach (var board in boards.ToArray())
            {
                board.AddNumber(number);
                if (board.Score > 0)
                {
                    yield return board;
                    boards.Remove(board);
                }
            }
        }
    }

    private sealed record Cell(string Number, bool Mark = false)
    {
        public override string ToString()
        {
            return $"Cell({Number}, {Mark})";
        }
    }

    class BingoBoard
    {
        private const int BoardSize = 5;
        private List<Cell> _cells;

        public BingoBoard(string st)
        {
            _cells = st.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(arr => arr.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                .SelectMany(x => x)
                .Select(t => new Cell(t.Trim()))
                .ToList();
        }

        public int Score { get; private set; }

        private IEnumerable<Cell> GetCellsByRowIndex(int rowIndex) =>
            Enumerable.Range(0, BoardSize)
                .Select(i => _cells[rowIndex * BoardSize + i]);

        private IEnumerable<Cell> GetCellsByColIndex(int colIndex) =>
            Enumerable.Range(0, BoardSize)
                .Select(i => _cells[i * BoardSize + colIndex]);

        public void AddNumber(string number)
        {
            var index = _cells.FindIndex(cell => cell.Number == number);

            if (index >= 0)
            {
                // mark the cell
                _cells[index] = new Cell(number, true);

                // check if the board is completed, compute score
                for (var i = 0; i < BoardSize; i++)
                {
                    if (
                        GetCellsByRowIndex(i).All(cell => cell.Mark) ||
                        GetCellsByColIndex(i).All(cell => cell.Mark)
                    )
                    {
                        var unmarkedNumbers = _cells
                            .Where(cell => cell.Mark == false)
                            .Select(cell => cell.Number)
                            .Select(int.Parse)
                            .ToList();

                        Score = int.Parse(number) * unmarkedNumbers.Sum();
                    }
                }
            }
        }

        // Debug method
        public void PrintBoardCells()
        {
            foreach (var cell in _cells)
            {
                Console.WriteLine(cell);
            }
        }
    }
}