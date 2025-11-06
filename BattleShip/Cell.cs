namespace BattleShip;

internal sealed class Cell
{
    public CellState State { get; set; } = CellState.Empty;

    public override string ToString()
    {
        return State switch
        {
            CellState.Empty or CellState.Alongside => "*",
            CellState.Damaged or CellState.Destroyed => "X",
            _ => "?"
        };
    }
}

