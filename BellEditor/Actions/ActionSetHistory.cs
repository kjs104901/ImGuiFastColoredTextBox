namespace BellEditor.Actions;

internal struct ActionSetHistory
{
    private const int MaxHistoryCount = 100;
    
    private readonly LinkedList<ActionSet> _history = new();

    public ActionSetHistory()
    {
    }

    public void AddHistory(ActionSet actionSet)
    {
        if (actionSet.HasEditAction)
        {
            _history.AddLast(actionSet);
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