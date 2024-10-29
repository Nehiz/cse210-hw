using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness App!");
            Thread.Sleep(3000);
            Console.WriteLine("Choose an activity from the list below:");
            Thread.Sleep(2000);
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Exit");
           
            Console.Write("Enter the number of the activity you want to start: ");
            string choice = Console.ReadLine();
            Activity activity = null; // Initialize activity to null

            // Request user input for custom duration if a valid choice is made
            if (choice == "1" || choice == "2" || choice == "3")
            {
                Console.Write("How long, in seconds, would you like for your session? ");
                int duration;
                while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
                {
                    Console.Write("Please enter  duration as a positive number: ");
                }

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity(duration);
                        break;
                    case "2":
                        activity = new ListingActivity(duration);
                        break;
                    case "3":
                        activity = new ReflectingActivity(duration);
                        break;
                }

                // Run the activity if a valid choice is made
                activity.Run();
            }
            else if (choice == "4")
            {
                running = false;
                Console.WriteLine("Exiting program...Goodbye!");
                Thread.Sleep(2000); // Wait for a bit before exiting for better user experince.
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Thread.Sleep(2000); // Brief pause to let user read the message
            }

            if (running)
            {
                Console.WriteLine("Would you like to run another activity? (y/n)");
                string response = Console.ReadLine().ToLower();
                if (response != "y")
                {
                    running = false;
                    Console.WriteLine("Exiting program ...Goodbye!");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}


// Some extra features that were added to the program beyond the core requirement to exceed expectation:

// 1. Spinner and Countdown Functions - The ShowSpinner (int seconds) function displays a spinner animation for a specified number of seconds, making the app feels more interactive and visually appealing.
// 2. Activity Duration Control - DateTime logic was added to track the start and end times of each activity, allowing for precise control over the duration.
// 3. Custom Duration Option - The program now allows users to choose a custom duration for each activity.
// 4. Activity Selection - The program now provides a menu to select different activities, such as Breathing, Listing, and Reflecting.  
// 5. Reflecting Activity with Controlled Prompt delay - The ReflectingActivity prompts are displayed with a delay in between to allow users time to think.
// 6. Continue or Exit Option - The program now allows users to choose to continue or exit the program after each activity.