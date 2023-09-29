namespace BellEditor.Data;

public struct Selection
{
    public Coordinates Begin;
    public Coordinates Cursor;

    public bool HasRange => Begin != Cursor;
}