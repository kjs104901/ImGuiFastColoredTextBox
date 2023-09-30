using Bell;
using Bell.Data;
using Bell.Render;
using ImGuiNET;

namespace ImGuiBellEditor;

public class ImGuiTextEditorBackend : ITextEditorBackend
{
    public void SetClipboard(string text)
    {
        throw new NotImplementedException();
    }

    public string GetClipboard()
    {
        throw new NotImplementedException();
    }

    public void Render(TextEditor textEditor, List<LineRender> lineRenders)
    {
        ImGui.Text($"THIS IS EDITOR RENDER");
    }

    public event EventHandler? OnRenderSizeChanged;
    public (float, float) GetRenderSize(char c)
    {
        return ValueTuple.Create(10.0f, 5.0f);
    }
}