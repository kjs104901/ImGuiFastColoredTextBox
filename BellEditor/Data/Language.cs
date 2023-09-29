namespace BellEditor.Data;

public class Language
{
    public List<string> LineComments = new();
    public List<ValueTuple<string, string>> BlockComments = new();

    public List<ValueTuple<string, string>> Foldings = new();

    public List<ValueTuple<string, Style>> PatternsStyle = new();
    public List<ValueTuple<string, Style>> KeywordsStyle = new();
    
    public string AutoIndentPattern = "";
    
    public static Language PlainText()
    {
        return new Language();
    }
}