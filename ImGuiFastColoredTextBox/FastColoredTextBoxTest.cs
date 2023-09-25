using ImGuiNET;
using System.Numerics;

namespace ImGuiFastColoredTextBox
{
    public class FastColoredTextBoxTest
    {
        public void Render(string title, Vector2 size = new(), bool showBorder = false)
        {
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0.0f, 0.0f));

            ImGui.BeginChild(title, size, showBorder,
                ImGuiWindowFlags.HorizontalScrollbar
                | ImGuiWindowFlags.AlwaysHorizontalScrollbar
                | ImGuiWindowFlags.NoMove);

            ImGui.BeginTooltip();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1.0f, 0.2f, 0.2f, 1.0f));
            ImGui.Text($"Error at line {1}:");
            ImGui.PopStyleColor();
            ImGui.Separator();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1.0f, 1.0f, 0.2f, 1.0f));
            ImGui.Text("error");
            ImGui.PopStyleColor();
            ImGui.EndTooltip();

            ImGui.EndChild();

            ImGui.PopStyleVar();
            ImGui.PopStyleColor();
        }
    }
}