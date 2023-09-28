namespace BellEditor.Actions;

internal class CopyAction : Action
{
    public override void Do(TextEditor textEditor)
    {
    }
}

internal class CutAction : EditAction
{
    public override void Do(TextEditor textEditor)
    {
    }

    public override void Undo(TextEditor textEditor)
    {
    }
}

internal class PasteAction : EditAction
{
    public override void Do(TextEditor textEditor)
    {
    }

    public override void Undo(TextEditor textEditor)
    {
    }
}