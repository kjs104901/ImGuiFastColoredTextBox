using BellEditor.Data;

namespace BellEditor;

public interface IBackend
{
    public void SetClipboard(string text);
    public string GetClipboard();

    public void Render(List<Selection> selections, List<LineDraw> lineDraws);

    public event EventHandler OnRenderSizeChanged;
    public ValueTuple<float, float> GetRenderSize(char c);
}