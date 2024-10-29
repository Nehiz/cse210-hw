using System;
using System.Collections.Generic;
using System.Threading;
class ReflectingActivity : Activity
{
    private List<string> _prompts;

    public ReflectingActivity(int duration) : base("Reflecting Activity", "This activity will help you reflect on the good things in your life.", duration)
    {
        _prompts = new List<string>
        {
            "Think of a time you overcame a challenge.",
            "Remember a moment when you helped someone.",
            "Think of a time when you did something really difficult.",
            "Reflect on a personal achievement."
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        int promptIndex = 0;

        while ((DateTime.Now - startTime).TotalSeconds < _duration && promptIndex < _prompts.Count)
        {
            Console.WriteLine(_prompts[promptIndex]);
            promptIndex = (promptIndex + 1) % _prompts.Count;

            // Wait for a few seconds before showing the next prompt
            ShowSpinner(10);
        }

        DisplayEndingMessage();
    }
}
/*
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful?",
        "What did you learn about yourself?",
        "How could you keep this experience in mind in the future?",
        "What made this time different than other times in your life?",
    };

    public ReflectingActivity(int duration)
        : base("Reflecting Activity", "This activity will help you reflect on the good things in your life.", duration) { }
    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Helper method to shuffle a list 
    private static void shuffle <T>(List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
    
    private void DisplayQuestions()
    {
        Console.WriteLine(GetRandomPrompt());

        // Shuffle questions for randomized order each time
        shuffle(_questions);

        // Display shuffled questions
        foreach (string question in _questions)
        {
            Console.WriteLine(question);
            ShowSpinner(2);
        }
    }

    public override void Run()
    {
        DisplayStartingMessage();
        DisplayQuestions();
        DisplayEndingMessage();
    }
} */