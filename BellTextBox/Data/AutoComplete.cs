namespace Bell.Data;

public class AutoComplete
{
    private readonly List<string> _list = new();
    private bool Enabled { get; set; }  = true;

    public void SetList(IEnumerable<string> list)
    {
        _list.Clear();
        _list.AddRange(list);
    }
}