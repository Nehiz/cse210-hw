using System;
using System.Collections.Generic;
using System.IO;

public class EternalQuestProgram
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void CreateGoal()
    {
        Console.WriteLine("What type of goal would you like to create? (1: Simple, 2: Eternal, 3: Checklist)");
        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter goal name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal;
        switch (choice)
        {
            case 1:
                goal = new SimpleGoal(name, description, points);
                break;
            case 2:
                goal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.WriteLine("Enter target completion count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid selection.");
                return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal added successfully!");
    }

    public void DeleteGoal()
    {
        ShowGoals();
        Console.WriteLine("Enter the index of the goal to delete:");
        
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < _goals.Count)
        {
            Console.WriteLine($"Are you sure you want to delete the goal: {_goals[index].GetStringRepresentation()}? (yes/no)");
            string confirmation = Console.ReadLine();
            if (confirmation.ToLower() == "yes")
            {
                _goals.RemoveAt(index);
                Console.WriteLine("Goal deleted successfully.");
            }
            else
            {
                Console.WriteLine("Goal deletion canceled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid index. No goal deleted.");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Enter goal name to record an event:");
        string goalName = Console.ReadLine();

        Goal goal = _goals.Find(g => g.GetStringRepresentation().Contains(goalName));
        if (goal != null)
        {
            goal.RecordEvent();

            if (goal is ChecklistGoal checklistGoal)
            {
                _score += checklistGoal.GetPoints();
                if (checklistGoal.IsComplete())
                {
                    _score += checklistGoal.CalculateBonus();
                }
            }
            else if (goal is SimpleGoal simpleGoal && simpleGoal.IsComplete())
            {
                _score += simpleGoal.GetPoints();
            }
            else if (goal is EternalGoal)
            {
                _score += goal.GetPoints(); // Award points for eternal goals each time recorded
            }

            Console.WriteLine($"{goalName} recorded. Total score: {_score}");
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void ShowGoals()
    {
        Console.Clear(); // Clears the console before displaying goals
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i}: {_goals[i].GetStringRepresentation()}");
        }
        Console.WriteLine($"Total score: {_score}");
    }

    public void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            outputFile.WriteLine(_score);  // Save current score first

            foreach (Goal goal in _goals)
            {
                if (goal is SimpleGoal simpleGoal)
                {
                    outputFile.WriteLine($"SimpleGoal|{simpleGoal.Name}|{simpleGoal.Description}|{simpleGoal.GetPoints()}|{simpleGoal.IsComplete()}");
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    outputFile.WriteLine($"EternalGoal|{eternalGoal.Name}|{eternalGoal.Description}|{eternalGoal.GetPoints()}");
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    outputFile.WriteLine($"ChecklistGoal|{checklistGoal.Name}|{checklistGoal.Description}|{checklistGoal.GetPoints()}|{checklistGoal.AmountCompleted}|{checklistGoal.Target}|{checklistGoal.CalculateBonus()}");
                }
            }
        }

        Console.WriteLine("Goals saved to goals.txt");
    }

    public void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        _goals.Clear(); // Clear current goals
        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            // Read the score first
            _score = int.Parse(reader.ReadLine());

            // Then, load each goal
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split('|'); // Split the line into parts
                Goal goal = null;

                switch (parts[0])
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}