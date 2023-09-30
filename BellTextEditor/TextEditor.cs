using Bell.Actions;
using Bell.Coordinates;
using Bell.Data;
using Bell.Inputs;
using Bell.Languages;

namespace Bell;

public enum WrapMode
{
    None,
    Word,
    BreakWord
}

public class TextEditor
{
    // Data
    public Page Page { get; set; } = new();
    public AutoComplete AutoComplete { get; set; }
    
    // Action
    private ActionSetHistory _actionSetHistory;
    private Cursor _cursor;
    
    // Options
    public bool AutoIndent { get; set; } = true;
    public bool Overwrite { get; set; } = false;
    public bool ReadOnly { get; set; } = false;
    public WrapMode WrapMode { get; set; } = WrapMode.Word;
    public bool SyntaxHighlighting { get; set; } = true;
    public bool SyntaxFolding { get; set; } = true;
    public Language Language { get; set; } = Language.PlainText();
    public int FontSize { get; set; } //TODO cache by size or just get # char size to check
    
    // Backend
    private ITextEditorBackend _textEditorBackend;
    
    public TextEditor(ITextEditorBackend textEditorBackend)
    {
        _textEditorBackend = textEditorBackend;
    }
    
    // Method
    public List<uint> FindText(string text)
    {
        return new();
    }

    public bool Goto(uint lineNumber)
    {
        return true;
    }
    
    public bool Fold(uint lineNumber)
    {
        return true;
    }

    public bool Unfold(uint lineNumber)
    {
        return true;
    }

    public void Render()
    {
        _textEditorBackend.Render(this, Page.Text.GetRender());
    }
    
    // Input
    public void Input(KeyboardInput keyboardInput, MouseInput mouseInput, ViewInput viewInput)
    {
        ProcessKeyboardHotKeys(keyboardInput.HotKeys);
        ProcessKeyboardChars(keyboardInput.Chars);
        ProcessMouseInput(keyboardInput.HotKeys, mouseInput);
        ProcessViewInput(viewInput);
    }

    private void DoSomething()
    {
        
    }

    private void DoAction(Actions.Action action)
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

    private void ProcessKeyboardHotKeys(HotKeys hk)
    {
        if (hk.HasFlag(HotKeys.Ctrl | HotKeys.Z)) // Undo
            _actionSetHistory.Undo();
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.Y)) // Redo
            _actionSetHistory.Redo();
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.C)) // copy
            DoAction(new CopyAction());
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.V)) // Paste
            DoAction(new PasteAction());
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.X)) // Cut
        {
            ActionSet actionSet = new();
            actionSet.Add(new CopyAction());
            actionSet.Add(new DeleteSelectionAction());
            actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.A)) // Select All
        {
            ActionSet actionSet = new();
            actionSet.Add(new MoveCursorSelectionAction(CursorMove.StartOfFile));
            actionSet.Add(new MoveCursorOriginAction(CursorMove.EndOfFile));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.Delete)) // Delete
        {
            ActionSet actionSet = new();
            if (_cursor.HasSelection)
            {
                actionSet.Add(new DeleteSelectionAction());
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            }
            else
            {
                if (hk.HasFlag(HotKeys.Shift))
                {
                    actionSet.Add(new DeleteLineAction());
                }
                else
                {
                    actionSet.Add(new DeleteForwardAction());
                }
            }
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.Backspace)) // Backspace
        {
            ActionSet actionSet = new();
            if (_cursor.HasSelection)
            {
                actionSet.Add(new DeleteSelectionAction());
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            }
            else
            {
                //TODO 시작이었다면 위로 머지
                actionSet.Add(new DeleteBackwardAction());
            }
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.Enter)) // Enter
        {
            ActionSet actionSet = new();
            if (_cursor.HasSelection)
            {
                actionSet.Add(new DeleteSelectionAction());
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            }
            //TODO SplitLine
            //actionSet.Add(new InputChar('\n'));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.Tab)) // Tab
        {
            ActionSet actionSet = new();
            if (_cursor.HasSelection)
            {
                actionSet.Add(new IndentSelection());
            }
            else
            {
                actionSet.Add(new InputChar('\t'));
            }
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.UpArrow)) // Move Up
        {
            ActionSet actionSet = new();
            actionSet.Add(new MoveCursorOriginAction(CursorMove.Up));
            if (false == hk.HasFlag(HotKeys.Shift))
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.DownArrow)) // Move Down
        {
            ActionSet actionSet = new();
            actionSet.Add(new MoveCursorOriginAction(CursorMove.Down));
            if (false == hk.HasFlag(HotKeys.Shift))
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.LeftArrow)) // Move Left
        {
            ActionSet actionSet = new();
            actionSet.Add(new MoveCursorOriginAction(CursorMove.Left));
            if (false == hk.HasFlag(HotKeys.Shift))
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.RightArrow)) // Move Right
        {
            ActionSet actionSet = new();
            actionSet.Add(new MoveCursorOriginAction(CursorMove.Right));
            if (false == hk.HasFlag(HotKeys.Shift))
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.PageUp)) // Move PageUp
        {
            ActionSet actionSet = new();
            actionSet.Add(new MoveCursorOriginAction(CursorMove.PageUp));
            if (false == hk.HasFlag(HotKeys.Shift))
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.PageDown)) // Move PageDown
        {
            ActionSet actionSet = new();
            actionSet.Add(new MoveCursorOriginAction(CursorMove.PageDown));
            if (false == hk.HasFlag(HotKeys.Shift))
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.Home))
        {
            ActionSet actionSet = new();

            actionSet.Add(hk.HasFlag(HotKeys.Ctrl)
                ? new MoveCursorOriginAction(CursorMove.EndOfFile)
                : new MoveCursorOriginAction(CursorMove.EndOfLine));

            if (false == hk.HasFlag(HotKeys.Shift))
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            DoActionSet(actionSet);
        }
        else if (hk.HasFlag(HotKeys.End))
        {
            ActionSet actionSet = new();

            actionSet.Add(hk.HasFlag(HotKeys.Ctrl)
                ? new MoveCursorOriginAction(CursorMove.StartOfFile)
                : new MoveCursorOriginAction(CursorMove.StartOfLine));

            if (false == hk.HasFlag(HotKeys.Shift))
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.Origin));
            DoActionSet(actionSet);
            
        }
        else if (hk.HasFlag(HotKeys.Insert))
        {
            Overwrite = !Overwrite;
        }
    }

    
    private void ProcessKeyboardChars(char[] keyboardInputChars)
    {
        ActionSet actionSet = new();
        foreach (char keyboardInputChar in keyboardInputChars)
        {
            if (keyboardInputChar == 0)
                continue;

            if (keyboardInputChar == '\n')
            {
                //Todo enter
                continue;
            }
            
            if (keyboardInputChar == '\t')
            {
                //Todo tab
                continue;
            }
            
            if (keyboardInputChar < 32)
                continue;

            actionSet.Add(new InputChar(keyboardInputChar));
        }
        DoActionSet(actionSet);
    }

    
    private void ProcessMouseInput(HotKeys hk, MouseInput mouseInput)
    {
        ViewCoordinates viewCoordinates = new(mouseInput.X, mouseInput.Y);
        if (false == viewCoordinates.ToPageCoordinates(
                Page,
                out PageCoordinates pageCoordinates,
                out bool isLine, out bool isMarker))
        {
            return;
        }

        if (isMarker)
        {
            //TODO find line and fold unfold

            return;
        }

        if (false == pageCoordinates.ToTextCoordinates(
                Page.Text,
                out TextCoordinates textCoordinates))
        {
            return;
        }

        if (MouseKey.Click == mouseInput.MouseKey)
        {
            if (hk.HasFlag(HotKeys.Shift))
            {
                DoAction(new MoveCursorSelectionAction(textCoordinates));
            }
            else
            {
                ActionSet actionSet = new();
                actionSet.Add(new MoveCursorSelectionAction(textCoordinates));
                actionSet.Add(new MoveCursorOriginAction(textCoordinates));
                DoActionSet(actionSet);
            }
        }
        else if (MouseKey.DoubleClick == mouseInput.MouseKey)
        {
            if (hk.HasFlag(HotKeys.Shift)) // Select Line
            {
                ActionSet actionSet = new();
                actionSet.Add(new MoveCursorOriginAction(textCoordinates));
                
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.StartOfLine));
                actionSet.Add(new MoveCursorOriginAction(CursorMove.EndOfLine));
                DoActionSet(actionSet);
            }
            else // Select word
            {
                ActionSet actionSet = new();
                actionSet.Add(new MoveCursorOriginAction(textCoordinates));
                
                actionSet.Add(new MoveCursorSelectionAction(CursorMove.StartOfWord));
                actionSet.Add(new MoveCursorOriginAction(CursorMove.EndOfWord));
                DoActionSet(actionSet);
            }
        }
        else if (MouseKey.Dragging == mouseInput.MouseKey)
        {
            DoAction(new MoveCursorSelectionAction(textCoordinates));
        }
    }

    private void ProcessViewInput(ViewInput viewInput)
    {
        ViewCoordinates start = new (viewInput.X, viewInput.Y);
        ViewCoordinates end = new (viewInput.X + viewInput.W, viewInput.Y + viewInput.H);
        Page.UpdateView(start, end);
    }
}