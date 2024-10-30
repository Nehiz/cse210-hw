using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration)
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 
        duration) { }
    
    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser(DateTime endTime)
    {
        List<string> items = new List<string>();
        
        // Display a random prompt and give time to think
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("Take a moment to think about the prompt.");
        ShowCountdown(5);

        Console.WriteLine("Now, please start listing items. Type done to finish early: ");

        // Allow the user to list items until time is up
        // DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;  // fix case sensistivity for 'done'
                
            items.Add(input);
            _count++;
        }

        return items;
    }
    
    public override void Run()
    {
        DisplayStartingMessage();

        // Capture start time and user responses
        DateTime activityStart = DateTime.Now;
        DateTime endTime = activityStart.AddSeconds(Duration);

        // Reset item count before each run
        _count = 0;

        // Prompt user to list items and capture their input
        List<string> userItems = GetListFromUser(endTime);
        
        if (userItems.Count == 0)
        {
            Console.WriteLine("You did not list any items. Please try again.");
        }
        else
        {
            // Display the number of items listed
            Console.WriteLine($"\nYou listed {_count} items!");
            Console.WriteLine("Here are the items you listed:");
            foreach (string item in userItems)
            {
                Console.WriteLine($"- {item}");
            }
        }

        // Show the actual time taken
        DisplayEndingMessage(activityStart);

    }
}