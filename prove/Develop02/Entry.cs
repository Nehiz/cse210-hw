public class Entry
{
    public string _date { get; private set; }
    public string _promptText { get; private set; }
    public string _entryText { get; set; } // Change to a property to maintain encapsulation while allowing the text to be changed in the journal externally.

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    // Method to display the entry details
    public void Display()
    {
        Console.WriteLine($"Date: {_date}\nPrompt: {_promptText }\nEntry: {_entryText}\n");
        Console.WriteLine("------------------------------------");
    }
}