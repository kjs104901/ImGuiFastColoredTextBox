using BellEditor.Language;

namespace BellEditor;

public enum WrapMode
{
    None,
    Word
}

public partial class TextEditor
{
    // Data
    //public string Text { get; set; }
    // 자주 가져가면 퍼포먼스 때문에 ToString 고려
    
    // Options
    public bool AutoIndent { get; set; } = true;
    public bool AutoComplete { get; set; } = true;
    public List<string> AutoCompleteList { get; set; } = new();
    public bool Overwrite { get; set; } = false;
    public bool ReadOnly { get; set; } = false;
    public WrapMode WrapMode { get; set; } = WrapMode.Word;
    public float LineHeaderWidth { get; set; } = 0.0f;
    public bool SyntaxHighlight { get; set; } = true;
    public bool SyntaxFolding { get; set; } = true;

    public IBackend Backend;
    public ILanguage Language { get; set; } = new DefaultLanguage();
    
    public TextEditor(IBackend backend)
    {
        Backend = backend;
    }
}