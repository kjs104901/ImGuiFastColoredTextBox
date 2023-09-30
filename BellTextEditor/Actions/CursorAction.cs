using Bell.Coordinates;

namespace Bell.Actions;

internal enum CursorMove
{
    None,
    
    Up,
    Down,
    Left,
    Right,
    
    StartOfFile,
    EndOfFile,
    StartOfLine,
    EndOfLine,
    StartOfWord,
    EndOfWord,
    
    PageUp,
    PageDown,
    
    Origin,
    Selection
}

internal class MoveCursorSelectionAction : Action
{
    private CursorMove _cursorMove = CursorMove.None;
    private TextCoordinates _textCoordinates;
    
    public MoveCursorSelectionAction(CursorMove cursorMove)
    {
        _cursorMove = cursorMove;
    }
    
    public MoveCursorSelectionAction(TextCoordinates textCoordinates)
    {
        _textCoordinates = textCoordinates;
    }
    
    public override void Do(TextEditor textEditor)
    {
    }
}

internal class MoveCursorOriginAction : Action
{
    private CursorMove _cursorMove = CursorMove.None;
    private TextCoordinates _textCoordinates;
    
    public MoveCursorOriginAction(CursorMove cursorMove)
    {
        _cursorMove = cursorMove;
    }
    
    public MoveCursorOriginAction(TextCoordinates textCoordinates)
    {
        _textCoordinates = textCoordinates;
    }
    
    public override void Do(TextEditor textEditor)
    {
    }
}