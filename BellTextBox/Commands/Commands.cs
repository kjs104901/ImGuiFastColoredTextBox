namespace Bell.Commands;

internal abstract class Commands
{
    public abstract void Do(TextBox textBox);
}

internal abstract class EditCommands : Commands
{
    public abstract void Undo(TextBox textBox);
}