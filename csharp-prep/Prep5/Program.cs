using System;

class Program
{
    static void Main(string[] args)
    {
        // Call each function in sequence and pass data as needed
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt the user for their name and return it as a string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }


    // Function to prompt the user for their favorite number and return it as an integer
    static int PromptUserNumber()
    {
        Console.Write("ParallelLoopState enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function to square a number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result with the user's name and squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

}