namespace BellEditor.Actions;

internal struct ActionSet
{
    private readonly List<Action> _actions = new();

    public ActionSet()
    {
    }

    public void Add(Action action)
    {
        _actions.Add(action);
    }

    public void Do(TextEditor textEditor)
    {
        foreach (Action action in _actions)
        {
            action.Do(textEditor);
        }
    }

    public void Undo(TextEditor textEditor)
    {
        foreach (Action action in _actions)
        {
            if (action is EditAction editAction)
            {
                editAction.Undo(textEditor);
            }
        }
    }

    public bool HasEditAction => _actions.Any(a => a is EditAction);
}