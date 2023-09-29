namespace BellEditor.Data;

public struct Text
{
    private readonly List<Line> _lines = new();
    private bool _needUpdate = false;

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