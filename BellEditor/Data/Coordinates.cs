namespace BellEditor.Data;

public struct Coordinates : IEquatable<Coordinates>
{
    public uint LineIndex;
    public uint ColumnIndex;

    public Coordinates(uint lineIndex, uint columnIndex)
    {
        LineIndex = lineIndex;
        ColumnIndex = columnIndex;
    }

    public bool Equals(Coordinates other)
    {
        return LineIndex == other.LineIndex && ColumnIndex == other.ColumnIndex;
    }

    public override bool Equals(object? obj)
    {
        return obj is Coordinates other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(LineIndex, ColumnIndex);
    }

    public static bool operator ==(Coordinates x, Coordinates y) => x.LineIndex == y.LineIndex && x.ColumnIndex == y.ColumnIndex;
    public static bool operator !=(Coordinates x, Coordinates y) => x.LineIndex != y.LineIndex || x.ColumnIndex != y.ColumnIndex; 
    public static bool operator <(Coordinates x, Coordinates y) => x.LineIndex != y.LineIndex ? x.LineIndex < y.LineIndex : x.ColumnIndex < y.ColumnIndex;
    public static bool operator >(Coordinates x, Coordinates y) => x.LineIndex != y.LineIndex ? x.LineIndex > y.LineIndex : x.ColumnIndex > y.ColumnIndex;
    public static bool operator <=(Coordinates x, Coordinates y) => x.LineIndex != y.LineIndex ? x.LineIndex < y.LineIndex : x.ColumnIndex <= y.ColumnIndex;
    public static bool operator >=(Coordinates x, Coordinates y) => x.LineIndex != y.LineIndex ? x.LineIndex > y.LineIndex : x.ColumnIndex >= y.ColumnIndex;
}