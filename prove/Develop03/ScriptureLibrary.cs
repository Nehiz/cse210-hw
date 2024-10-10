using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class ScriptureLibrary
{
    private List<Scripture> scriptures = new List<Scripture>();

    // Method to Load default scriptures into the list
    public void LoadScriptures()
    {
        scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not periesh, but have everlasting life."));
        scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
        scriptures.Add(new Scripture(new Reference("Isaiah", 41, 10), "Fear thou not; for I am with thee: be not dismayed; for I am thy God: I will strengthen thee; yea, I will help thee; yea, I will uphold thee with the right hand of my righteousness."));
        scriptures.Add(new Scripture(new Reference("Philippians", 4, 13), " I can do all things through Christ which stregtheneth me."));
        scriptures.Add(new Scripture(new Reference("1 Nephi", 20, 10), "For, behold, I have refined thee, I have chosen thee in the furnace of affliction."));
        scriptures.Add(new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy."));
        scriptures.Add(new Scripture(new Reference("Alma", 36, 3), "Whosoever shall put their trust in God shall be supported in their trials, and their troubles, and their afflictions, and shall be lifted up at the last day."));
        scriptures.Add(new Scripture(new Reference("D&C", 82, 10), "I, the Lord, am bound when ye do what I say; but when ye do not what I say, ye have no promise."));
        scriptures.Add(new Scripture(new Reference("D&C", 18, 10), "Remember the worth of souls is great in the sight of God."));
        // Adding I can add more scriptures as I need.
    }

    // Method to load scriptures from a file
    public void LoadScripturesFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string [] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string reference = parts[0].Trim();
                string scriptureText = parts[1].Trim();

                string[] refParts = reference.Split(' ');
                string book = refParts[0];
                string[] chapterAndVerse = refParts[1].Split(':');
                int chapter = int.Parse(chapterAndVerse[0]);
                int verse = int.Parse(chapterAndVerse[1]);

                scriptures.Add(new Scripture(new Reference(book, chapter, verse), scriptureText));
            }
        }
        else
        {
            Console.WriteLine("File not found. Please check the path and try again.");
        }
    }

    // Method to get a random scripture from the list
    public Scripture GetRandomSCripture()
    {
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures loaded.");
            return null;
        }

        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }
}