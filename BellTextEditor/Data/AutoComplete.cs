namespace Bell.Data;

public struct AutoComplete
{
    private readonly List<string> _list = new();
    private bool Enabled { get; set; }  = true;

    public AutoComplete()
    {
    }

    public void SetList(IEnumerable<string> list)
    {
        _list.Clear();
        _list.AddRange(list);
    }
}