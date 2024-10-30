using System;
using System.Collections.Generic;

class MeditationActivity : Activity
{
    public MeditationActivity(int duration)
        : base("Guided Meditation", "This activity will guide you through a short meditation session. Focus on calming your mind.", duration) {}

    public override void Run()
    {
        
        DisplayStartingMessage();  // Display Starting Message

        
        DateTime startTime = DateTime.Now;  // Start timing the activity
        DateTime endTime = startTime.AddSeconds(Duration);

        
        Console.WriteLine("Begin your mediation:");  // Perform the guided mediation activity until specific time if reached
        
        while (DateTime.Now < endTime)
        {
            // Calculate the remaining time to avoid exceeding the set duration
            TimeSpan timeRemaining = endTime - DateTime.Now;
            
            if (timeRemaining.TotalSeconds <= 2) break;
            Console.WriteLine("Take a breath in...");
            Thread.Sleep(2000);

            timeRemaining = endTime - DateTime.Now;
            if (timeRemaining.TotalSeconds <= 2) break;
            Console.WriteLine("Hold it for a moment...");
            Thread.Sleep(2000);

            timeRemaining = endTime - DateTime.Now;
            if (timeRemaining.TotalSeconds <= 2) break;
            Console.WriteLine("Take a breath out...");
            Thread.Sleep(2000);

            timeRemaining = endTime - DateTime.Now;
            if (timeRemaining.TotalSeconds <= 2) break;
            Console.WriteLine("Focus on your thoughts and let them flow...");
            Thread.Sleep(5000);
        }

        // Show completion message
        Console.WriteLine("You have completed the Meditation Activity!");
        DisplayEndingMessage(startTime);
    }
}