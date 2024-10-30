using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    private int _duration;


    // Single Random instance for the entire program to improve randomness
    protected static Random _random = new Random();

    // Constructor to accept a custom duration as a parameter
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    // Expose Duration as a public property
    public int Duration
    {
        get { return _duration; }
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name}.");
        Thread.Sleep(1000); // Wait for 1 second before starting the activity
        Console.WriteLine(_description);
        Console.WriteLine($"Duration: {_duration} seconds.");

        // Countdown before activity begins
        Console.WriteLine("Get ready to start...");
        ShowCountdown(5); // countdown from 5 seconds
        
        Console.WriteLine("Press Enter to start.");
        Console.ReadLine();
    }

    public void DisplayEndingMessage(DateTime startTime)
    {
        TimeSpan duration = DateTime.Now - startTime; // Calculate duration
        Console.WriteLine($"Good Job! You have completed the {_name} for {duration.TotalSeconds:F2} seconds!");
        Thread.Sleep(2000); // Wait for 2 second before ending the activity
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/\b");
            Thread.Sleep(250);
            Console.Write("-\b");
            Thread.Sleep(250);
            Console.Write("\\\b");
            Thread.Sleep(250);
            Console.Write("|\b");
            Thread.Sleep(250);
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Run();
}


