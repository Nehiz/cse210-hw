using System;
using System.Collections.Generic;
using System.Threading;
class BreathingActivity : Activity
{
    public BreathingActivity(int duration)
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration) {}

    public override void Run()
    {
        
        DisplayStartingMessage();  // Display the starting message and countdown

        
        DateTime startTime = DateTime.Now;  // Start timing the activity
        DateTime endTime = startTime.AddSeconds(Duration);

        
        while (DateTime.Now < endTime)  // Perform the breathing exercise until specific time if reached
        {
            
            TimeSpan timeRemaining = endTime - DateTime.Now;  // Calculate the remaining time to avoid exceeding the set duration

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
        
        
        DisplayEndingMessage(startTime);  // Show completion message
    }

   
    private void ShowExpandingText(string message, int totalTime)   // Helper method for expanding text
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