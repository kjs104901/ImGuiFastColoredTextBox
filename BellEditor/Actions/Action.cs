namespace BellEditor.Actions;

internal abstract class Action
{
    public abstract void Do(TextEditor textEditor);
}

internal abstract class EditAction : Action
{
    public abstract void Undo(TextEditor textEditor);
}