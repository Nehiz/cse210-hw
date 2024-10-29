using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    // Single Random instance for the entire program to improve randomness
    protected static Random _random = new Random();

    // Constructor modified to accept a custom duration as a parameter
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name}.");
        Thread.Sleep(1000); // Wait for 1 second before starting the activity
        Console.WriteLine(_description);
        Console.WriteLine($"Duration: {_duration} seconds.");
        Console.WriteLine("Press Enter to start.");
        Console.ReadLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds!");
        Thread.Sleep(2000); // Wait for 1 second before ending the activity
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


