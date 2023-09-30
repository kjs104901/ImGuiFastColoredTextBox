using System.Text;

namespace Bell.Actions;

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

    public string GetDebugString()
    {
        return string.Join(",", _actions.Select(a => a.GetType().ToString()));
    }
}