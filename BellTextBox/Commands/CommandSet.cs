namespace Bell.Commands;

internal struct CommandSet
{
    private readonly List<Commands> _actions = new();

    public CommandSet()
    {
    }

    public void Add(Commands commands)
    {
        _actions.Add(commands);
    }

    public void Do(TextBox textBox)
    {
        foreach (Commands action in _actions)
        {
            action.Do(textBox);
        }
    }

    public void Undo(TextBox textBox)
    {
        foreach (Commands action in _actions)
        {
            if (action is EditCommands editAction)
            {
                editAction.Undo(textBox);
            }
        }
    }

    public bool HasEditAction => _actions.Any(a => a is EditCommands);

    public string GetDebugString()
    {
        return string.Join(",", _actions.Select(a => a.GetType().ToString()));
    }
}