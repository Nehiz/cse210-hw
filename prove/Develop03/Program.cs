using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        // Example scripture: John 3: 16
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, " For God so loved the world that he gave his only begotten Son, that whosoever believeth in himshould not perish, but have everlasting life.");

        // Program loop
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