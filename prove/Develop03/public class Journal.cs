public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }
}

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string prompt, string entry)
    {
        _date = date;
        _promptText = prompt;
        _entryText = entry;
    }

    public void Display()
    {
        Console.WriteLine($"{_date}: {_promptText} - {_entryText}");
    }
}