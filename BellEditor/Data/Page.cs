namespace BellEditor.Data;

public struct Page
{
    private Text _text = new();
    
    private bool _dirty = false;

    public Page()
    {
    }
}