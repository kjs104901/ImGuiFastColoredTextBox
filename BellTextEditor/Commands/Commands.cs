namespace Bell.Commands;

internal abstract class Commands
{
    public abstract void Do(TextEditor textEditor);
}

internal abstract class EditCommands : Commands
{
    public abstract void Undo(TextEditor textEditor);
}