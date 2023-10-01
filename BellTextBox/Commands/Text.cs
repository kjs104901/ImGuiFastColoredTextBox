namespace Bell.Commands;

// InputChar
// InputString

// DeleteBackward
// DeleteForward

// IndentSelection
// DeleteSelection

// SplitLine
// MergeForwardLine
// MergeBackwardLine
// DeleteLine

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

internal class InputChar : EditCommands
{
    private char _c;
    public InputChar(char c)
    {
        _c = c;
    }
    
    public override void Do(TextBox textBox)
    {
    }

    public override void Undo(TextBox textBox)
    {
    }
}

internal class IndentSelection : EditCommands
{
    public override void Do(TextBox textBox)
    {
    }

    public override void Undo(TextBox textBox)
    {
    }
}

internal class DeleteSelectionCommands : EditCommands
{
    public override void Do(TextBox textBox)
    {
    }

    public override void Undo(TextBox textBox)
    {
    }
}

internal class DeleteForwardCommands : EditCommands
{
    public override void Do(TextBox textBox)
    {
    }

    public override void Undo(TextBox textBox)
    {
    }
}

internal class DeleteBackwardCommands : EditCommands
{
    public override void Do(TextBox textBox)
    {
    }

    public override void Undo(TextBox textBox)
    {
    }
}

internal class DeleteLineCommands : EditCommands
{
    public override void Do(TextBox textBox)
    {
    }

    public override void Undo(TextBox textBox)
    {
    }
}


internal class CopyCommands : Commands
{
    public override void Do(TextBox textBox)
    {
    }
}

internal class PasteCommands : EditCommands
{
    public override void Do(TextBox textBox)
    {
    }

    public override void Undo(TextBox textBox)
    {
    }
}