using BellEditor.Actions;
using BellEditor.Data;
using BellEditor.Inputs;
using Action = BellEditor.Actions.Action;

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
    
    // Action
    private ActionSetHistory _actionSetHistory;
    private Selection _selection;
    
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

    private void DoAction(Action action)
    {
        ActionSet actionSet = new ActionSet();
        actionSet.Add(action);
        
        DoActionSet(actionSet);
    }
    
    private void DoActionSet(ActionSet actionSet)
    {
        actionSet.Do(this);
        _actionSetHistory.AddHistory(actionSet);
    }

    private void ProcessKeyboardInput(KeyboardInput keyboardInput)
    {
        var hk = keyboardInput.HotKeys;

        if (hk.HasFlag(HotKeys.Ctrl | HotKeys.Z)) // Undo
            _actionSetHistory.Undo();
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.Y)) // Redo
            _actionSetHistory.Redo();
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.C)) // copy
            DoAction(new CopyAction());
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.V)) // Paste
            DoAction(new PasteAction());
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.X)) // Cut
            DoAction(new CutAction());
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.A)) // Select All
        {
            DoAction(new SetSelectionAction(new() {
                Begin = new Coordinates(0, 0),
                Cursor = new Coordinates(10, 10), //TODO last line and last column
            }));
        }
        else if (hk.HasFlag(HotKeys.Delete)) // Delete
        {
            ActionSet actionSet = new();
            if (_selection.HasRange)
            {
                actionSet.Add(new DeleteSelectionAction());
                actionSet.Add(new RemoveSelectionRangeAction());
            }
            else
            {
                actionSet.Add(new DeleteForwardAction());
            }
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.Backspace)) // Backspace
        {
            ActionSet actionSet = new();
            if (_selection.HasRange)
            {
                actionSet.Add(new DeleteSelectionAction());
                actionSet.Add(new RemoveSelectionRangeAction());
            }
            else
            {
                actionSet.Add(new DeleteBackwardAction());
            }
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.Enter)) // Enter
        {
            ActionSet actionSet = new();
            if (_selection.HasRange)
            {
                actionSet.Add(new DeleteSelectionAction());
                actionSet.Add(new RemoveSelectionRangeAction());
            }
            actionSet.Add(new InputChar('\n'));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.Tab)) // Tab
        {
            ActionSet actionSet = new();
            if (_selection.HasRange)
            {
                actionSet.Add(new IndentSelection());
            }
            else
            {
                actionSet.Add(new InputChar('\t'));
            }
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.Shift | HotKeys.UpArrow))
            DoSomething(); // Select Up
        else if (hk.HasFlag(HotKeys.Shift | HotKeys.DownArrow))
            DoSomething(); // Select Down
        else if (hk.HasFlag(HotKeys.Shift | HotKeys.LeftArrow))
            DoSomething(); // Select Left
        else if (hk.HasFlag(HotKeys.Shift | HotKeys.RightArrow))
            DoSomething(); // Select Right
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