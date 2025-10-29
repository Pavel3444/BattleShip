using System.Text;

namespace BattleShip;

internal sealed class Board
{
    private const int BoardSide = 10;
    private const string HorizontalCoords = "    А  Б  В  Г  Д  Е  Ж  З  И  К";
    private readonly Cell[,] _board;

    public Board()
    {
        _board = new Cell[BoardSide, BoardSide];
        for (int v = 0; v < BoardSide; v++)
        {
            for (int h = 0; h < BoardSide; h++)
            {
                _board[v, h] = new Cell();
            }
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
}