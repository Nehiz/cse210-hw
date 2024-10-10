using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        // prompt the user to either manually add scriptures, load scriptures from a file or
        // go straight to memorizing by ramdonly selectly a scripture to memorize.
       
        ScriptureLibrary library = new ScriptureLibrary();

        Console.WriteLine("Welcome to the scripture memorizer!");
        Console.WriteLine("Would you like to:");
        Console.WriteLine("1. Enter scriptures manually to memorize");
        Console.WriteLine("2. Load scriptures from a file");
        Console.WriteLine("3. Randomly select a scriptures to memorize");
        Console.Write("Please enter 1, 2, or 3: ");
        string choice = Console.ReadLine();

        // Handle each choice
        if (choice == "1")
        {
            Console.WriteLine("Enter a scripture reference (e.g., John 3:16):");
            string reference = Console.ReadLine();

            Console.WriteLine("Enter the scripture text:");
            string scriptureText = Console.ReadLine();

            string[] refParts =  reference.Split(' ');
            string book = refParts[0];
            string[] chapterAndVerse = refParts[1].Split(':');
            int chapter = int.Parse(chapterAndVerse[0]);
            int verse = int.Parse(chapterAndVerse[1]);

            Scripture scripture = new Scripture(new Reference(book, chapter, verse), scriptureText);
            RunMemorizerProgram(scripture);
        }
        else if (choice == "2")
        {
            Console.WriteLine("Enter the file path for scriptures:");
            string filePath = Console.ReadLine();
            library.LoadScripturesFromFile(filePath);
            Scripture scripture = library.GetRandomSCripture();
            RunMemorizerProgram(scripture);
        }
        else if (choice == "3")
        {
            library.LoadScriptures(); // Preload some default scriptures
            Scripture scripture = library.GetRandomSCripture();
            RunMemorizerProgram(scripture);
        }
        else
        {
            Console.WriteLine("invalid choice. Please restart the program and enter 1, 2, or 3");
        }
    }

        /*
        // Example scripture: John 3: 16
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, " For God so loved the world that he gave his only begotten Son, that whosoever believeth in himshould not perish, but have everlasting life.");
        */

    // Method to run the memorizer loop
    static void RunMemorizerProgram(Scripture scripture)
    {
        // Program loop for memorization
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type  'quit' to end.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            break;

            scripture.HideRandomWords(3); // hide 3 random words
        }
        Console.WriteLine("All words are hidden. Well done!");
    }
}

  // Showed creativity by:
        // Improving user interaction by providing multiple pathways to start scripture memorization, making the program more versatile.
        // Added Manual Scripture entry logic to let the user specific their own scripture to memorize instead of relying on preloaded scriptures.
        // Added loading scriptures from file logic to allow batch entry of scriptures and flexibilty in managing large amounts of content.
        // Added random scripture selection logic to provide the user a convenient way to use the program and memorize randomly selected scriptures without manual input or file loading.
        // Added a new class ScriptureLibrary to manage scripture data, including loading from a file and storing scriptures. 
        // This new class (ScriptureLibrary) abstracts the logic scriptures, allowing better organization and easier future modification.
        // Added RunMemorizerProgram method logic to hide a random number of words from the scripture with each iteration. This makes the program a little more dynamic.
        // Add a simple logic to inform the user of a wrong entry and restart the program.
