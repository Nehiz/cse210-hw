using System;
using System.Collections.Generic;
using System.Threading;
class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(int duration) : base("Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in your daily life.", duration)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this experience meaningful to you?",
            "What was your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();

        // Select a random prompt
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(5);

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            // Select a random question from list
            string question = _questions[_random.Next(_questions.Count)];
            Console.WriteLine(question);

            // Wait for a few seconds before showing the next question
            ShowSpinner(5);

            // Check if we've reached the duration before displaying the next question
            if ((DateTime.Now - startTime).TotalSeconds >= Duration)
            break;
        
        }

        DisplayEndingMessage(startTime);
    }
}