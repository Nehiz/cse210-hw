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
            Console.WriteLine("Breathe in...");
            ShowSpinner(2);
            Thread.Sleep(2000);

            Console.WriteLine("Now breathe out...");
            ShowSpinner(2);
            Thread.Sleep(2000);
        }
        // DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;

        // Show completion message with the actual duration
        Console.WriteLine($"You have completed the Breathing Activity for {duration.TotalSeconds:F2} seconds!");
    }
    
}