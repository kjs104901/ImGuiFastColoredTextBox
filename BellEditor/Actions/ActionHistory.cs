namespace BellEditor.Actions;

internal struct ActionHistory
{
    private const int MaxHistoryCount = 100;
    
    private readonly LinkedList<EditAction> _history = new();

    public ActionHistory()
    {
    }

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