public class Word
{
    // Member variables
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Method stub
    public void Hide()
    {
        _isHidden = true;
    }

    public void show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? "_ _ _ _" : _text;
    }
}