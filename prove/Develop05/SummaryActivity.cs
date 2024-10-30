using System;
using System.Collections.Generic;

class SummaryActivity : Activity
{
    private Dictionary<string, int> activityCounts;
    public SummaryActivity(int duration) 
        : base("Daily Summary", "This activity summarizes your activities for the day.", duration) 
        {
            activityCounts = new Dictionary<string, int>();
        }

    public void LogActivity(string activityName)
    {
        if (activityCounts.ContainsKey(activityName))
        {
            activityCounts[activityName]++;
        }
        else
        {
            activityCounts[activityName] = 1;
        }
    }
    
    public override void Run()
    {
        DisplayStartingMessage();

        LogActivity("Breathing Activity");
        LogActivity("Listing Activity");
        LogActivity("Reflecting Activity");

       
        Console.WriteLine("\n---Activity Summary: ");   // Display the summary of activities
        foreach (var kvp in activityCounts)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} times");
        }

        DisplayEndingMessage(DateTime.Now);
    }
}
