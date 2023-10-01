using Bell.Commands;
using Bell.Coordinates;
using Bell.Data;
using Bell.Inputs;
using Bell.Languages;

namespace Bell;

public partial class TextBox
{
    // Data
    public Page Page { get; set; } = new();
    public AutoComplete AutoComplete { get; set; } = new();
    
    // Action
    private readonly CommandSetHistory _commandSetHistory = new();
    private readonly Cursor _cursor = new();
    
    private readonly ITextBoxBackend _textBoxBackend;
    
    public TextBox(ITextBoxBackend textBoxBackend)
    {
        _textBoxBackend = textBoxBackend;
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
        _textBoxBackend.Render(this, Page.Text.GetRender());
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

    private void DoAction(Commands.Commands commands)
    {
        CommandSet commandSet = new CommandSet();
        commandSet.Add(commands);
        DoActionSet(commandSet);
    }
    
    private void DoActionSet(CommandSet commandSet)
    {
        commandSet.Do(this);
        _commandSetHistory.AddHistory(commandSet);
    }

    private void ProcessKeyboardHotKeys(HotKeys hk)
    {
        if (hk.HasFlag(HotKeys.Ctrl | HotKeys.Z)) // Undo
            _commandSetHistory.Undo();
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.Y)) // Redo
            _commandSetHistory.Redo();
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.C)) // copy
            DoAction(new CopyCommands());
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.V)) // Paste
            DoAction(new PasteCommands());
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.X)) // Cut
        {
            CommandSet commandSet = new();
            commandSet.Add(new CopyCommands());
            commandSet.Add(new DeleteSelectionCommands());
            commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.Ctrl | HotKeys.A)) // Select All
        {
            CommandSet commandSet = new();
            commandSet.Add(new MoveCursorSelectionCommands(CursorMove.StartOfFile));
            commandSet.Add(new MoveCursorOriginCommands(CursorMove.EndOfFile));
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.Delete)) // Delete
        {
            CommandSet commandSet = new();
            if (_cursor.HasSelection)
            {
                commandSet.Add(new DeleteSelectionCommands());
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            }
            else
            {
                if (hk.HasFlag(HotKeys.Shift))
                {
                    commandSet.Add(new DeleteLineCommands());
                }
                else
                {
                    commandSet.Add(new DeleteForwardCommands());
                }
            }
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.Backspace)) // Backspace
        {
            CommandSet commandSet = new();
            if (_cursor.HasSelection)
            {
                commandSet.Add(new DeleteSelectionCommands());
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            }
            else
            {
                //TODO 시작이었다면 위로 머지
                commandSet.Add(new DeleteBackwardCommands());
            }
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.Enter)) // Enter
        {
            CommandSet commandSet = new();
            if (_cursor.HasSelection)
            {
                commandSet.Add(new DeleteSelectionCommands());
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            }
            //TODO SplitLine
            //actionSet.Add(new InputChar('\n'));
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.Tab)) // Tab
        {
            CommandSet commandSet = new();
            if (_cursor.HasSelection)
            {
                commandSet.Add(new IndentSelection());
            }
            else
            {
                commandSet.Add(new InputChar('\t'));
            }
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.UpArrow)) // Move Up
        {
            CommandSet commandSet = new();
            commandSet.Add(new MoveCursorOriginCommands(CursorMove.Up));
            if (false == hk.HasFlag(HotKeys.Shift))
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.DownArrow)) // Move Down
        {
            CommandSet commandSet = new();
            commandSet.Add(new MoveCursorOriginCommands(CursorMove.Down));
            if (false == hk.HasFlag(HotKeys.Shift))
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.LeftArrow)) // Move Left
        {
            CommandSet commandSet = new();
            commandSet.Add(new MoveCursorOriginCommands(CursorMove.Left));
            if (false == hk.HasFlag(HotKeys.Shift))
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.RightArrow)) // Move Right
        {
            CommandSet commandSet = new();
            commandSet.Add(new MoveCursorOriginCommands(CursorMove.Right));
            if (false == hk.HasFlag(HotKeys.Shift))
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.PageUp)) // Move PageUp
        {
            CommandSet commandSet = new();
            commandSet.Add(new MoveCursorOriginCommands(CursorMove.PageUp));
            if (false == hk.HasFlag(HotKeys.Shift))
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.PageDown)) // Move PageDown
        {
            CommandSet commandSet = new();
            commandSet.Add(new MoveCursorOriginCommands(CursorMove.PageDown));
            if (false == hk.HasFlag(HotKeys.Shift))
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.Home))
        {
            CommandSet commandSet = new();

            commandSet.Add(hk.HasFlag(HotKeys.Ctrl)
                ? new MoveCursorOriginCommands(CursorMove.EndOfFile)
                : new MoveCursorOriginCommands(CursorMove.EndOfLine));

            if (false == hk.HasFlag(HotKeys.Shift))
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            DoActionSet(commandSet);
        }
        else if (hk.HasFlag(HotKeys.End))
        {
            CommandSet commandSet = new();

            commandSet.Add(hk.HasFlag(HotKeys.Ctrl)
                ? new MoveCursorOriginCommands(CursorMove.StartOfFile)
                : new MoveCursorOriginCommands(CursorMove.StartOfLine));

            if (false == hk.HasFlag(HotKeys.Shift))
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.Origin));
            DoActionSet(commandSet);
            
        }
        else if (hk.HasFlag(HotKeys.Insert))
        {
            Overwrite = !Overwrite;
        }
    }

    
    private void ProcessKeyboardChars(char[] keyboardInputChars)
    {
        CommandSet commandSet = new();
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

            commandSet.Add(new InputChar(keyboardInputChar));
        }
        DoActionSet(commandSet);
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
                DoAction(new MoveCursorSelectionCommands(textCoordinates));
            }
            else
            {
                CommandSet commandSet = new();
                commandSet.Add(new MoveCursorSelectionCommands(textCoordinates));
                commandSet.Add(new MoveCursorOriginCommands(textCoordinates));
                DoActionSet(commandSet);
            }
        }
        else if (MouseKey.DoubleClick == mouseInput.MouseKey)
        {
            if (hk.HasFlag(HotKeys.Shift)) // Select Line
            {
                CommandSet commandSet = new();
                commandSet.Add(new MoveCursorOriginCommands(textCoordinates));
                
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.StartOfLine));
                commandSet.Add(new MoveCursorOriginCommands(CursorMove.EndOfLine));
                DoActionSet(commandSet);
            }
            else // Select word
            {
                CommandSet commandSet = new();
                commandSet.Add(new MoveCursorOriginCommands(textCoordinates));
                
                commandSet.Add(new MoveCursorSelectionCommands(CursorMove.StartOfWord));
                commandSet.Add(new MoveCursorOriginCommands(CursorMove.EndOfWord));
                DoActionSet(commandSet);
            }
        }
        else if (MouseKey.Dragging == mouseInput.MouseKey)
        {
            DoAction(new MoveCursorSelectionCommands(textCoordinates));
        }
    }

    private void ProcessViewInput(ViewInput viewInput)
    {
        ViewCoordinates start = new (viewInput.X, viewInput.Y);
        ViewCoordinates end = new (viewInput.X + viewInput.W, viewInput.Y + viewInput.H);
        Page.UpdateView(start, end);
    }
}