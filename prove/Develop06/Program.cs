class Program
{
    static void Main(string[] args)
    {
        EternalQuestProgram questProgram = new EternalQuestProgram();
        int choice = -1; // Initialize choice with a default value

        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Show Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Progress");
            Console.WriteLine("5. Load Progress");
            Console.WriteLine("6. Delete Goal");
            Console.WriteLine("0. Quit");
            Console.Write("Enter your choice: ");

            // Check for valid input
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        questProgram.CreateGoal();
                        break;
                    case 2:
                        questProgram.ShowGoals();
                        break;
                    case 3:
                        questProgram.RecordEvent();
                        break;
                    case 4:
                        questProgram.SaveGoals();
                        break;
                    case 5:
                        questProgram.LoadGoals();
                        break;
                    case 6:
                        questProgram.DeleteGoal();
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        // Handle invalid menu selection
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
            else
            {
                // Handle non-integer input
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (choice != 0); // Continue until user decides to quit
    }
}


/* Features added to show creativity and exceed expectation
1. Logic to show the index of the goals when displayed using the show goals method.
2. logic to delete already entered goal.
2. Logic to handle error with entering of invalid character.
*/