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
        Random rnd = new ();
        Line line = (Line)rnd.Next(0, 2);;
        int x;
        int y;
        do
        {
             x = rnd.Next(0, 10);
             y = rnd.Next(0, 10);
        } while (!TryPlaceShip(line, shipSize,x, y));
    }

    private bool TryPlaceShip(Line line, int shipSize, int x, int y)
    {
        return line switch
        {
            Line.Horizontal => TryPlaceShipHorizontal(shipSize, x, y),
            Line.Vertical => TryPlaceShipVertical(shipSize, x, y),
            _ => true
        };
    }

    private bool TryPlaceShipHorizontal(int shipSize, int x, int y)
    {
        throw new NotImplementedException();
    }

    private bool TryPlaceShipVertical(int shipSize, int x, int y)
    {
        throw new NotImplementedException();
    }
}