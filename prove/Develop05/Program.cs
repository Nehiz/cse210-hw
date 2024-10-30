using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    const string BreathingActivityKey = "1";
    const string ListingActivityKey = "2";
    const string ReflectingActivityKey = "3";
    const string MeditationActivityKey = "4";
    const string ExitActivityKey = "0";

    static void Main(string[] args)
    {
        bool isRunning = true;

        
        SummaryActivity summaryActivity = new SummaryActivity(0);  // Create an instance of SummaryActivity to log all completed activities

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness App!");
            Thread.Sleep(3000);
            Console.WriteLine("Choose an activity from the list below:");
            Thread.Sleep(2000);

            
            var activities = new Dictionary<string, Func<int, Activity>>  // Define the activity options in a dictionary for easier management
            {
                {BreathingActivityKey, (duration) => new BreathingActivity(duration)},
                {ListingActivityKey, (duration) => new ListingActivity(duration)}, 
                {ReflectingActivityKey, (duration) => new ReflectingActivity(duration)},
                {MeditationActivityKey, (duration) => new MeditationActivity(duration)}
            };

           
            Console.WriteLine("1. Breathing Activity");   // Display the activity options with names
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Meditation Activity");
            Console.WriteLine("0. Exit"); 
           
            
            Console.Write("Enter the number of the activity you want to start: ");
            string choice = Console.ReadLine();

            
            if (activities.ContainsKey(choice))  // Request user input for custom duration if a valid choice is made
            {
                Console.Write("How long, in seconds, would you like for your session? ");
                int duration;
                while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
                {
                    Console.Write("Please enter  duration as a positive number: ");
                }
    
                
                Activity selectedActivity = activities[choice](duration); // Instantiate the activity using the dictionary
                selectedActivity.Run();

                // Inform user that the activity has been completed
                Console.WriteLine("Activity completed! Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == ExitActivityKey)
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

/* extra logics and functions added to exceed expectations
1. Added logic to enable the DisplayEndingMessage method in the activity class to write log entry to a file 
named activity_log.txt everytime an activity completes. This provides users with a record of what they have done.
2. Added an extra activity 'Meditation Activity' to guide users through a time meditation.
3. Added a modular activity dictionary in the main program to manage activities and user selections to allow easy modification of functions.
4. Added logic to reduce the error in timing the duration, ensuring the program starts counting after the coundown.
*/