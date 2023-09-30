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
        ImGui.Text("----- textEditor start -----");
        foreach (LineRender lineRender in lineRenders)
        {
            ImGui.Text(lineRender.Text);
        }
        ImGui.Text("----- textEditor end -----");
    }

    public (float, float) GetRenderSize(char c)
    {
        return ValueTuple.Create(10.0f, 5.0f);
    }
}