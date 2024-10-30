using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    const string BreathingActivityKey = "1";
    const string ListingActivityKey = "2";
    const string ReflectingActivityKey = "3";
    const string ExitActivityKey = "4";

    static void Main(string[] args)
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness App!");
            Thread.Sleep(3000);
            Console.WriteLine("Choose an activity from the list below:");
            Thread.Sleep(2000);

            // Define the activity options in a dictionary for easier management
            var activities = new Dictionary<string, Func<int, Activity>>
            {
                {BreathingActivityKey, (duration) => new BreathingActivity(duration)},
                {ListingActivityKey, (duration) => new ListingActivity(duration)}, 
                {ReflectingActivityKey, (duration) => new ReflectingActivity(duration)}
            };

            // Display the activity options with names
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Exit"); 
           
            
            Console.Write("Enter the number of the activity you want to start: ");
            string choice = Console.ReadLine();
            // Activity activity = null; // Initialize activity to null

            // Request user input for custom duration if a valid choice is made
            if (activities.ContainsKey(choice))
            {
                Console.Write("How long, in seconds, would you like for your session? ");
                int duration;
                while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
                {
                    Console.Write("Please enter  duration as a positive number: ");
                }
    
                // Instantiate the activity using the dictionary
                Activity selectedActivity = activities[choice](duration);
                selectedActivity.Run();

                // Inform user that the activity has been completed
                // Console.WriteLine("Activity completed. Thank you for using the Mindfulness App!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "4")
            {
                isRunning = false;
                Console.WriteLine("Exiting program...Goodbye!");
                Thread.Sleep(2000); // Wait for a bit before exiting for better user experince.
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Thread.Sleep(2000); // Brief pause to let user read the message
            }

            if (isRunning)
            {
                Console.WriteLine("Would you like to run another activity? (y/n)");
                string response = Console.ReadLine().ToLower();
                if (response != "y")
                {
                    isRunning = false;
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