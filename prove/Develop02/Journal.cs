public class Journal
{
    private List<Entry> _entries;
    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Method to add a new entry
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Method to display all entries
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Method to save entries to a file
    public void SaveToFile(string filePath)
    {
        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date};{entry._promptText};{entry._entryText}");
            }
        }
    }
    
    // Methods to load entries from a file
    public void LoadFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            if (parts.Length == 3) // To ensure there are no issues with improperly formatted lines
            {
                string date = parts[0];
                string promptText = parts[1];
                string entryText = parts[2];

                Entry newEntry = new Entry(date, promptText, entryText);
                _entries.Add(newEntry);
            }
        }
    }
}