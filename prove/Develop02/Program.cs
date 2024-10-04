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

                default:
                    Console.WriteLine("invalid choice. Please try again.");
                    break;

            }
            Console.WriteLine();
        }
    }
}
