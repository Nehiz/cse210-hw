using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display all journal entries");
            Console.WriteLine("3. save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Search entries");
            Console.WriteLine("7. Edit an entry");   // menu for exceeding expectation starts here
            Console.WriteLine("8. Delete an entry");
            Console.WriteLine("9. Display entries by date");
            Console.WriteLine("10. Export journal to CSV");
            Console.WriteLine("11. Export journal to PDF");
            Console.WriteLine("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Get a random prompt
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");

                    // Get user input for the journal entry
                    Console.Write("Your response: ");
                    string entryText = Console.ReadLine();

                    // Create a new entry with the current date
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    Entry entry = new Entry(date, prompt, entryText);

                    // Add the entry to the journal
                    journal.AddEntry(entry);
                    break;

                case "2":
                    // Display all entries
                    journal.DisplayAll();
                    break;

                case "3":
                    // Save journal to file
                    Console.Write("Enter the file path to save the journal: ");
                    string savePath = Console.ReadLine();
                    /*journal.SaveToFile(savePath); // Success or error handled inside the method
                    break;*/
                    try
                    {
                        journal.SaveToFile(savePath);
                        Console.WriteLine("Journal saved successfully!");
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Error saving journal: {ex.Message}");
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine($"Permission error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }
                    break;

                case "4":
                    // Load journal from file
                    Console.Write("Enter the file path to load the journal: ");
                    string loadPath = Console.ReadLine();
                    /*journal.LoadFromFile(loadPath);
                    Console.WriteLine("Journal loaded successfully!");
                    break;*/
                    // Added error handling around the LoadFromFile~
                    try
                    {
                        journal.LoadFromFile(loadPath);
                        Console.WriteLine("Journal loaded successfully!");
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Error load journal: {ex.Message}");
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine($"Permission error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }
                    break;

                case "5":
                    // Quit the program
                    running = false;
                    break;

                case "6":
                    // Search entries
                    Console.Write("Enter a keyword to search: ");
                    string keyword = Console.ReadLine();
                    journal.SearchEntries(keyword);
                    break;

                case "7":
                    // Edit entries
                    Console.Write("Enter the index of the entry to edit: ");
                    if (int.TryParse(Console.ReadLine(), out int editIndex))
                    
                    {
                        Console.Write("Enter the new entry text: ");
                        string newEntryText = Console.ReadLine();
                        journal.EditEntry(editIndex, newEntryText);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index. Please enter a number.");
                    }
                    break;

                case "8":
                    // Delete Journal entry
                    Console.Write("Enter the index of the entry to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                    {
                    journal.DeleteEntry(deleteIndex);
                    }
                    break;

                case "9":
                    Console.Write("Enter the date (yyyy-MM-dd) to display entries: ");
                    string displayDate = Console.ReadLine();
                    journal.DisplayEntriesByDate(displayDate);
                    break;

                case "10": // Export to CSV
                    Console.Write("Enter the file path to save as CSV: ");
                    string csvPath = Console.ReadLine();
                    try
                    {
                        journal.ExportToCsv(csvPath);
                        Console.WriteLine("Journal exported to CSV successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error exporting to CSV: {ex.Message}");
                    }
                    break;
                case "11": // Export to PDF
                    Console.Write("Enter the file path to save as Pdf: ");
                    string pdfPath = Console.ReadLine();
                    try
                    {
                        journal.ExportToPdf(pdfPath);
                        Console.WriteLine("Journal exported to PDF successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error exporting to PDF: {ex.Message}");
                    }
                    break;

                default:
                    Console.WriteLine("invalid choice. Please try again.");
                    break;

            }
            Console.WriteLine();
        }
    }
}


// exceeding Requirements:
// 1. Added logic for the program to do the following extra functions for enhanced user experience: 
// Edit Entries: Modify existing entries by selecting them with thier index
// Delete Entries: Remove entries from the journal, so entires entred for testing purposes can be delted.
// Search Entries: Find entries based on keywords regardless of letter case, date and indexes.
// Display Entries by Date: View entries for a specific date.

// 2. Added logic to handle error or other issues associated with saving and loading files,
// such as: invalid file paths, permisssion issues, or files being in use. These logic prevents the 
// program from crashing when it encounters such issue.

// 3. Added logic to display each entry with an index, making it easy to locate, edit, or delete entries.
// Also,  Programs gives feedback for every respond to the prompt by the user.

// 4. Alongside other functionalities, I also added logic to export to pdf and csv file format.
    // also, 
            // The program is able to load entries from the .txt file.
            // The program can save and load entries from files, which allows users to keep their journal even after closing the program. 
            // The program is structured with multiple classes (JournalEntry and Journal) to demonstrate abstraction, encapsulating related functionalities and data.