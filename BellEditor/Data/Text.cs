namespace BellEditor.Data;

public struct Text
{
    private readonly List<Line> _lines = new();
    private readonly List<LineView> _lineViews = new();
    
    private bool _dirty = false;

    public Text()
    {
    }

    public void Set(string text)
    {
        
    }

    public override string ToString()
    {
        return string.Empty;
    }
}