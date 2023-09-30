using System.Text;

namespace Bell.Actions;

internal struct ActionSetHistory
{
    private const int Capacity = 1000;
    private readonly LinkedList<ActionSet> _history = new();
    private readonly LinkedList<ActionSet> _redoHistory = new();

    public ActionSetHistory()
    {
    }

    public void AddHistory(ActionSet actionSet)
    {
        if (actionSet.HasEditAction)
        {
            _history.AddLast(actionSet);
            if (_history.Count > Capacity)
            {
                _history.RemoveFirst();
            }
            _redoHistory.Clear();
        }
    }
    
    public void Undo()
    {
        if (_history.Last == null)
            return;

        var action = _history.Last.Value;

        _redoHistory.AddFirst(action);
    }

    public void Redo()
    {
        if (_redoHistory.First == null)
            return;

        var action = _redoHistory.First.Value;

        _history.AddLast(action);
    }

    public string GetDebugString()
    {
        StringBuilder sb = new();
        sb.AppendLine("History");
        foreach (ActionSet actionSet in _history)
        {
            sb.Append("[");
            sb.Append(actionSet.GetDebugString());
            sb.Append("]");
            sb.AppendLine();
        }
        sb.AppendLine("Redo History");
        foreach (ActionSet actionSet in _redoHistory)
        {
            sb.Append("[");
            sb.Append(actionSet.GetDebugString());
            sb.Append("]");
            sb.AppendLine();
        }
        return sb.ToString();
    }
}