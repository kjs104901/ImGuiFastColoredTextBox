using Bell.Coordinates;

namespace Bell.Data;

public class Page
{
    public Text Text = new();
    
    private bool _sizeDirty = false;

    public float Width { get; private set; } = 0.0f;
    public float Height { get; private set; } = 0.0f;
    
    public bool LineNumberVisible { get; set; } = true;
    public float LineNumberWidth { get; set; } = 20.0f; // TODO auto calculate + set padding
    
    public bool MarkerVisible { get; set; } = true;
    public float MarkerWidth { get; set; } = 10.0f;
    
    // View
    private ViewCoordinates _viewStart = new ();
    private ViewCoordinates _viewEnd = new ();

    private uint _viewLineStart = 0;
    private uint _viewLineEnd = 0;
    private bool _viewLineDirty = false;
    
    public void UpdateView(ViewCoordinates start, ViewCoordinates end)
    {
        _viewStart = start;
        _viewEnd = end;
        
        _viewLineDirty = true;
    }
}