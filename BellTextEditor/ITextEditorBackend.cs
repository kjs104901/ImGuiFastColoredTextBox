﻿using Bell.Render;

namespace Bell;

public interface ITextEditorBackend
{
    public void SetClipboard(string text);
    public string GetClipboard();

    public void Render(TextEditor textEditor, List<LineRender> lineRenders);
    public ValueTuple<float, float> GetRenderSize(char c);
}