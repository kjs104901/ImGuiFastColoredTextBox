namespace Bell.Data;

[Flags]
public enum Marker
{
    None = 0,
    
    Fold = 1 << 0,
    Unfold = 1 << 1
}