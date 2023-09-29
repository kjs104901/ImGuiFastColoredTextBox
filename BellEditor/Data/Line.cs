namespace BellEditor.Data;

public struct LineView
{
    public Line Line;
    public uint Index;
}

public class Line
{
    private uint _index = 0;
    private List<Glyph> _glyphs = new();

    private bool _visible = false;
    private bool _folded = false;

    private List<uint> _cutoffs = new List<uint>();

    public int ViewCount
    {
        get
        {
            return 1;
        }
    }
    
    private Marker _marker = Marker.None;
    
    private bool _dirty = false;

    public Line()
    {
    }
}