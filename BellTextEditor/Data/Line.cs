using Bell.Render;

namespace Bell.Data;

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

    public void Set(string line)
    {
        _glyphs.Clear();
        foreach (char c in line)
        {
            _glyphs.Add(new Glyph(c));
        }
    }

    public LineRender GetRender()
    {
        var lineRender = new LineRender();
        lineRender.Text = "";
        foreach (Glyph glyph in _glyphs)
        {
            lineRender.Text += glyph.Char;
        }
        return lineRender;
    }
}