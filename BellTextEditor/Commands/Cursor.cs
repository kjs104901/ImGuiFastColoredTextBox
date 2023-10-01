using Bell.Coordinates;

namespace Bell.Commands;

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

internal class MoveCursorSelectionCommands : Commands
{
    private CursorMove _cursorMove = CursorMove.None;
    private TextCoordinates _textCoordinates;
    
    public MoveCursorSelectionCommands(CursorMove cursorMove)
    {
        _cursorMove = cursorMove;
    }
    
    public MoveCursorSelectionCommands(TextCoordinates textCoordinates)
    {
        _textCoordinates = textCoordinates;
    }
    
    public override void Do(TextEditor textEditor)
    {
    }
}

internal class MoveCursorOriginCommands : Commands
{
    private CursorMove _cursorMove = CursorMove.None;
    private TextCoordinates _textCoordinates;
    
    public MoveCursorOriginCommands(CursorMove cursorMove)
    {
        _cursorMove = cursorMove;
    }
    
    public MoveCursorOriginCommands(TextCoordinates textCoordinates)
    {
        _textCoordinates = textCoordinates;
    }
    
    public override void Do(TextEditor textEditor)
    {
    }
}