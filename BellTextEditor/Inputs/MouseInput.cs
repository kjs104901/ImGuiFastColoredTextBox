namespace Bell.Inputs;

public enum MouseKey
{
    None,
    
    Click,
    DoubleClick,
    Dragging
}

public struct MouseInput
{
    public MouseKey MouseKey;
}