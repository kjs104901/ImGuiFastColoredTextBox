using Bell.Render;

namespace Bell.Data;

public class Text
{
    private readonly List<Line> _lines = new();
    private readonly List<LineView> _lineViews = new();
    private bool _viewDirty = false;

    private readonly List<LineRender> _lineRenders = new();
    private bool _renderDirty = false;
    
    public void Set(string text)
    {
        _lines.Clear();
        foreach (string lineText in text.Split("\n"))
        {
            Line line = new Line();
            line.Set(lineText);
            _lines.Add(line);
        }
        _viewDirty = true;
        _renderDirty = true;
    }

    public List<LineRender> GetRender()
    {
        UpdateRender();
        return _lineRenders;
    }

    private void UpdateRender()
    {
        if (_renderDirty)
        {
            _lineRenders.Clear();
            foreach (Line line in _lines)
            {
                _lineRenders.Add(line.GetRender());
            }
            _renderDirty = false;
        }
    }

    public override string ToString()
    {
        return string.Empty;
    }
}