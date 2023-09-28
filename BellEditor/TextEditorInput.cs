using BellEditor.Inputs;

namespace BellEditor;

public partial class TextEditor
{
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