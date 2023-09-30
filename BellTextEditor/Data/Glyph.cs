namespace Bell.Data;

public struct Glyph
{
    private readonly char _char;
    private Style? _style = null;
    
    public Glyph(char c)
    {
        _char = c;
    }
}