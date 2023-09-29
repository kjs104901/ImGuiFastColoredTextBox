using BellEditor.Data;
using BellEditor.Inputs;
using BellEditor.Language;

namespace BellEditor;

public enum WrapMode
{
    None,
    Word
}

public class TextEditor
{
    // Data
    public Page Page { get; set; }
    public PageView PageView { get; set; }
    public AutoComplete AutoComplete { get; set; }
    
    // Options
    public bool AutoIndent { get; set; } = true;
    public bool Overwrite { get; set; } = false;
    public bool ReadOnly { get; set; } = false;
    public WrapMode WrapMode { get; set; } = WrapMode.Word;
    public float LineHeaderWidth { get; set; } = 0.0f;
    public bool SyntaxHighlight { get; set; } = true;
    public bool SyntaxFolding { get; set; } = true;
    public Language Language { get; set; } = Language.PlainText();
    
    // Backend
    private IBackend _backend;
    
    public TextEditor(IBackend backend)
    {
        _backend = backend;
    }
    
    // Actions
    public List<uint> FindText(string text)
    {
        return new();
    }

    public bool Goto(uint lineNumber)
    {
        return true;
    }
    
    // Input
    public void Input(KeyboardInput keyboardInput, MouseInput mouseInput, ViewInput viewInput)
    {
        ProcessKeyboardInput(keyboardInput);
        ProcessMouseInput(keyboardInput, mouseInput);
        ProcessViewInput(viewInput);
    }
    
    private void DoSomething()
    {
        
    }

    private void ProcessKeyboardInput(KeyboardInput keyboardInput)
    {
        var hk = keyboardInput.HotKeys;

        if (hk.HasFlag(HotKeys.Ctrl | HotKeys.Z))
            DoSomething(); // Undo
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.Y))
            DoSomething(); // Redo
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.C))
            DoSomething(); // copy
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.A))
            DoSomething(); // All
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.V))
            DoSomething(); // Paste
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.X))
            DoSomething(); // Cut
        else if (hk.HasFlag(HotKeys.Delete))
            DoSomething(); // Delete
        else if (hk.HasFlag(HotKeys.Backspace))
            DoSomething(); // Backspace
        else if (hk.HasFlag(HotKeys.Enter))
            DoSomething(); // Enter
        else if (hk.HasFlag(HotKeys.Tab))
            DoSomething(); // Tab
        else if (hk.HasFlag(HotKeys.UpArrow))
            DoSomething(); // UpArrow
        else if (hk.HasFlag(HotKeys.DownArrow))
            DoSomething(); // DownArrow
        else if (hk.HasFlag(HotKeys.LeftArrow))
            DoSomething(); // LeftArrow
        else if (hk.HasFlag(HotKeys.RightArrow))
            DoSomething(); // RightArrow
        else if (hk.HasFlag(HotKeys.PageUp))
            DoSomething(); // PageUp
        else if (hk.HasFlag(HotKeys.PageDown))
            DoSomething(); // PageDown
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.Home))
            DoSomething(); // Home (start of file)
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.End))
            DoSomething(); // End (end of file)
        else if (hk.HasFlag(HotKeys.Home))
            DoSomething(); // Home (start of line)
        else if (hk.HasFlag(HotKeys.End))
            DoSomething(); // End (end of line)
        else if (hk.HasFlag(HotKeys.Insert))
            DoSomething(); // Insert
        
    }

    private void ProcessMouseInput(KeyboardInput keyboardInput, MouseInput mouseInput)
    {
        if (MouseKey.Click == mouseInput.MouseKey)
        {
            if (keyboardInput.HotKeys.HasFlag(HotKeys.Alt | HotKeys.Shift))
            {
                // rect select
            }
            else if (keyboardInput.HotKeys.HasFlag(HotKeys.Alt))
            {
                // add cursor
            }
            else if (keyboardInput.HotKeys.HasFlag(HotKeys.Shift))
            {
                // multi line select
            }
            else
            {
                // set cursor
            }
        }
        else if (MouseKey.DoubleClick == mouseInput.MouseKey)
        {
            // Select word
        }
        else if (MouseKey.Dragging == mouseInput.MouseKey)
        {
            // cursor move
            // multi line select
        }
    }

    private void ProcessViewInput(ViewInput viewInput)
    {
        // update view of editor
    }
}