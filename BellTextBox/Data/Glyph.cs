namespace Bell.Data;

public struct Glyph
{
    public readonly char Char;
    private Style? _style = null;
    
    public Glyph(char c)
    {
        Char = c;
    }
}