using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

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
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"Index {i}:");
            _entries[i].Display();  // Call the display method of the Entry class
            Console.WriteLine("------------------------------");
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

    // Extra functionality for enhanced user experience.
    // 1. Entry Search Functionality
    public void SearchEntries(string keyword)
    {
        var matchingEntries = _entries.Where(entry => entry._entryText.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        if (matchingEntries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            foreach (var entry in matchingEntries)
            {
                entry.Display();
            }
        }
    }
    

    // 2. Edit Existing Entries
    public void EditEntry(int index, string newEntryText)
    {
        if (index >= 0 && index < _entries.Count)
        {
            _entries[index]._entryText = newEntryText;
            Console.WriteLine("Entry updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid entry index.");
        }
    }

    // 3. Delete Entries
    public void DeleteEntry(int index)
    {
        if (index >= 0 && index <_entries.Count)
        {
            _entries.RemoveAt(index);
            Console.WriteLine("Entry deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid entry index.");
        }
    }

    // 4. Display Entries by Date
    public void DisplayEntriesByDate(string date)
    {
        var filteredEntries = _entries.Where(entry => entry._date == date).ToList();

        if (filteredEntries.Count == 0)
        {
            Console.WriteLine("No entries found for this date.");
        }
        else
        {
            foreach (var entry in filteredEntries)
            {
                entry.Display();
            }
        }
    }

    // 5. Save journal entries as a PDF document.
    public void ExportToPdf(string filePath)
    {
        using (PdfWriter writer = new PdfWriter(filePath))
        {
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                iText.Layout.Document document = new iText.Layout.Document(pdf);  // To explicitly specify Itext.Layout as the Document class to use at this stage.
                foreach (Entry entry in _entries)
                {
                    document.Add(new Paragraph($"Date: {entry._date}"));
                    document.Add(new Paragraph($"Prompt: {entry._promptText}"));
                    document.Add(new Paragraph($"Entry: {entry._entryText}"));
                    document.Add(new Paragraph("------------------------------"));
                }
            }
        }
    }
    // 6. Save entries to a CSV file.
    public void ExportToCsv(string filePath)
    {
        using (StreamWriter write = new StreamWriter(filePath))
        {
            foreach (Entry entry in _entries)
            {
                // Escape quotes and commas
                string date = entry._date.Replace("\"", "\"\""); // Escape quotes
                string promptText = entry._promptText.Replace("\"", "\"\"").Replace(",", " "); // Escape quotes and replace commas
                string entryText = entry._entryText.Replace("\"", "\"\"").Replace(",", " "); // Escape quotes and replace commas

                write.WriteLine($"\"{date}\",\"{promptText}\",\"{entryText}\"");
            }
        }
    }


}