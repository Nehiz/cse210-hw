using System;
using System.Collections.Generic;
using System.Threading;
class BreathingActivity : Activity
{
    public BreathingActivity(int duration)
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration) {}

    public override void Run()
    {
        // Display the starting message and countdown
        DisplayStartingMessage();

        // Start timing the activity
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Duration);

        // Perform the breathing exercise until specific time if reached
        while (DateTime.Now < endTime)
        {
            // Calculate the remaining time to avoid exceeding the set duration
            TimeSpan timeRemaining = endTime - DateTime.Now;

            if (timeRemaining.TotalSeconds <= 2) break;
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000);

            
            timeRemaining = endTime - DateTime.Now;
            if (timeRemaining.TotalSeconds <= 2) break;
            Console.Clear();
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000);
            ShowExpandingText("Breathe out", 2000);
            
            timeRemaining = endTime - DateTime.Now;
            if (timeRemaining.TotalSeconds <= 2) break;
            Console.Clear();
            Console.WriteLine("Now breathe out", 2000);
            Thread.Sleep(2000);
            ShowExpandingText("Breathe in", 2000);
        }
        
        // Show completion message
        DisplayEndingMessage(startTime);
    }

    // Helper method for expanding text
    private void ShowExpandingText(string message, int totalTime)
    {
        int delay = totalTime / message.Length;
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }
    
}