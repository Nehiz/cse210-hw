public class Entry
{
    public string _date { get; private set; }
    public string _promptText { get; private set; }
    public string _entryText { get; private set; }

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    // Method to display the entry details
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText }");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine("------------------------------------");
    }
}