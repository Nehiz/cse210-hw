using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement: Ask student for the grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);

        // Initiatlize the letter grade variable
        string letter = "";

        // Core requirement 1: Series of if-else if-else statements to determine the letter grade based on percentage
        // and print statement for each grade letter.
        if (percentage >= 90)
        {
            // Console.WriteLine("Your grade is: A");
            letter = "A";
        }
        else if (percentage >= 80)
        {
             // Console.WriteLine("Your grade is: B");
            letter = "B";
        }
         else if (percentage >= 70)
        {
            // Console.WriteLine("Your grade is: C");
            letter = "C";
        }
         else if (percentage >= 60)
        {
            // Console.WriteLine("Your grade is: D");
            letter = "D";
        }
        else
        {
            // Console.WriteLine("Your grade is: F");
            letter = "F";
        }

        // Core requirement 3: Print the letter grade once
       Console.WriteLine($"Your grade is: {letter}");

       Console.WriteLine();

        //  Core req 2: Determine if the user passed or failed
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations Chap! You passed the class.");
        }
        else
        {
            Console.WriteLine("Work Harder! You can do this.");
        }

        // Stretch challenge: 
        // stretch 1: Add a "+" or "-" to the grade
        string sign = "";
        int lastDigit = percentage % 10;  // % operator is to get the remainder of the division (i.e the last digit of the numbers when they are divided by 10)

        // Only add "+" or "-" for grades B, C, D
        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Stretch 2: Special case for "A" grades, no A+ but allow A-
        if (letter == "A" && lastDigit <3)
        {
            sign = "-";
        }

        // Stretch 3: Special case for "F" grades, no F+ or F-
        if (letter == "F")
        {
            sign = "";
        }

        // Print the final grade with letter and sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

    }
}