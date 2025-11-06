using System.Text;

namespace BattleShip;

internal sealed class Board
{
    private const int BoardSide = 10;
    private const string HorizontalCoords = "    А  Б  В  Г  Д  Е  Ж  З  И  К";
    private readonly Cell[,] _board;
    private readonly int[] _ships = [4, 3, 3, 2, 2, 2, 1, 1, 1, 1];

    public Board(bool autoGenerate = true)
    {
        _board = new Cell[BoardSide, BoardSide];
        for (int v = 0; v < BoardSide; v++)
        {
            for (int h = 0; h < BoardSide; h++)
            {
                _board[v, h] = new Cell();
            }
        }

        if (autoGenerate)
        {
            GenerateShips();
        }
        
    }
    
    public void Print()
    {
        Console.WriteLine(HorizontalCoords);

        for (int v = 0; v < BoardSide; v++)
        {
            StringBuilder sb = new();
            sb.Append($"{v + 1}".PadRight(3));
            for (int h = 0; h < BoardSide; h++)
            {
                sb.Append(" ");
                sb.Append(_board[v, h]);
                sb.Append(" ");
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }

    private void GenerateShips()
    {
        foreach (var shipSize in _ships)
        {
            CalculateShip(shipSize);
        }
    }

    private void CalculateShip(int shipSize)
    {
        Random rnd = new();
        Line line = (Line)rnd.Next(0, 2);

        int x;
        int y;
        bool placed;

        do
        {
            if (line == Line.Horizontal)
            {
                 x = rnd.Next(0, BoardSide - shipSize + 1);
                y = rnd.Next(0, BoardSide);
            }
            else
            {
                 x = rnd.Next(0, BoardSide);
                y = rnd.Next(0, BoardSide - shipSize + 1);
            }

            placed = TryPlaceShip(line, shipSize, x, y);
        } while (!placed);
    }

    private bool TryPlaceShip(Line line, int shipSize, int x, int y)
    {
        return line switch
        {
            Line.Horizontal => TryPlaceShipHorizontal(shipSize, x, y),
            Line.Vertical => TryPlaceShipVertical(shipSize, x, y),
            _ => false
        };
    }

    private bool TryPlaceShipHorizontal(int shipSize, int x, int y)
    {
        int leftCoord = x;
        int rightCoord = x + shipSize - 1;

        if (rightCoord >= BoardSide) return false;

        int leftIndex = Math.Max(0, leftCoord - 1);
        int rightIndex = Math.Min(BoardSide - 1, rightCoord + 1);
        int lowIndex = Math.Max(0, y - 1);
        int highIndex = Math.Min(BoardSide - 1, y + 1);

        if (HasNeighbour(leftIndex, rightIndex, lowIndex, highIndex))
            return false;

        for (int h = leftCoord; h <= rightCoord; h++)
        {
            _board[y, h].State = CellState.Unbroken;
        }

        return true;
    }

    private bool TryPlaceShipVertical(int shipSize, int x, int y)
    {
        int lowCoord = y;
        int highCoord = y + shipSize - 1;

         if (highCoord >= BoardSide) return false;

        int lowIndex = Math.Max(0, lowCoord - 1);
        int highIndex = Math.Min(BoardSide - 1, highCoord + 1);
        int leftIndex = Math.Max(0, x - 1);
        int rightIndex = Math.Min(BoardSide - 1, x + 1);

        if (HasNeighbour(leftIndex, rightIndex, lowIndex, highIndex))
            return false;

        for (int v = lowCoord; v <= highCoord; v++)
        {
            _board[v, x].State = CellState.Unbroken;
        }

        return true;
    }

    private bool HasNeighbour(int leftIndex, int rightIndex, int lowIndex, int highIndex)
    {
        for (int v = lowIndex; v <= highIndex; v++)
        {
            for (int h = leftIndex; h <= rightIndex; h++)
            {
                if (_board[v,h].State == CellState.Unbroken)
                {
                    return true;
                }
            }
        }

        return false;
    }
}