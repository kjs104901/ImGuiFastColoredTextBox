namespace BellEditor.Actions;

// InputChar
// InputString

// DeleteBackward
// DeleteForward

// IndentSelection
// DeleteSelection

// InsertLine
// MergeLine

/* undo 정보
    public string? Added;
    public Coordinates AddedStart;
    public Coordinates AddedEnd;

    public string? Removed;
    public Coordinates RemovedStart;
    public Coordinates RemovedEnd;

    public SelectionState Before;
    public SelectionState After;

 */

internal class InputChar : EditAction
{
    private char _c;
    public InputChar(char c)
    {
        _c = c;
    }
    
    public override void Do(TextEditor textEditor)
    {
    }

    public override void Undo(TextEditor textEditor)
    {
    }
}

internal class IndentSelection : EditAction
{
    public override void Do(TextEditor textEditor)
    {
    }

    public override void Undo(TextEditor textEditor)
    {
    }
}

internal class DeleteSelectionAction : EditAction
{
    public override void Do(TextEditor textEditor)
    {
    }

    public override void Undo(TextEditor textEditor)
    {
    }
}

internal class DeleteForwardAction : EditAction
{
    public override void Do(TextEditor textEditor)
    {
    }

    public override void Undo(TextEditor textEditor)
    {
    }
}

internal class DeleteBackwardAction : EditAction
{
    public override void Do(TextEditor textEditor)
    {
    }

    public override void Undo(TextEditor textEditor)
    {
    }
}