using System.Numerics;
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
        ImGui.BeginChild("Editor", new Vector2(0, 0), true, ImGuiWindowFlags.HorizontalScrollbar);
        ImGui.BeginChild("Page", new Vector2(500, 1000), false, ImGuiWindowFlags.NoScrollbar);

        ImGui.Text("----- textEditor start -----");
        foreach (LineRender lineRender in lineRenders)
        {
            ImGui.Text(lineRender.Text);
        }
        ImGui.Text("----- textEditor end -----");
        
        ImGui.EndChild();
        ImGui.EndChild();
    }

    public (float, float) GetRenderSize(char c)
    {
        return ValueTuple.Create(10.0f, 5.0f);
    }
}