using BellEditor.Actions;
using Action = BellEditor.Actions.Action;

namespace BellEditor;

internal class ActionHistory
{
    private const int MaxHistoryCount = 100;
    
    private readonly LinkedList<EditAction> _history = new();

    public void AddHistory(Action action)
    {
        if (action is EditAction editAction)
        {
            _history.AddLast(editAction);
            if (_history.Count > MaxHistoryCount)
            {
                _history.RemoveFirst();
            }
        }
    }
    
    public void Undo()
    {
        
    }

    public void Redo()
    {
        
    }
}