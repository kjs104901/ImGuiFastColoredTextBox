namespace BellEditor.Data;

public struct Glyph
{
    private readonly char _char;
    private uint _style = 0;
    
    public Glyph(char c)
    {
        _char = c;
    }
}