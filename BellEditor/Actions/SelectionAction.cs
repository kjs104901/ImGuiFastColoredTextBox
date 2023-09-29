using BellEditor.Data;

namespace BellEditor.Actions;

internal class SetSelectionAction : Action
{
    private readonly Selection _selection;
    
    public SetSelectionAction(Selection selection)
    {
        _selection = selection;
    }
    
    public override void Do(TextEditor textEditor)
    {
    }
}

internal class RemoveSelectionRangeAction : Action
{
    public override void Do(TextEditor textEditor)
    {
    }
}

internal class MoveSelectionAction : Action
{
    public override void Do(TextEditor textEditor)
    {
        /*
        Up
        Down
        Left
        Right
        ToStartOfFile
        ToEndOfFile
        ToStartOfLine
        ToEndOfLine
         */
    }
}