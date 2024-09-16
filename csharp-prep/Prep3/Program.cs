using System;

class Program
{
    static void Main(string[] args)
    {
        //Stretch challenge 2:
        string playAgain = "yes"; // Variable to control game replay

        while (playAgain == "yes");
        {

        
                            /* Task 1: Start by asking users for magic number.

        // step 1: Ask the user for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());
        
        // Step 2: Ask the user for a guess
        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());
        
        // Step 3: use if statement to determine if the user needs to guess higher or lower
        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }                   */
        
                            // Task 3 : Instead of asking user for magic number, the program automatically generate a random magic number between 1 and 100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        // Stretch Challenge 1: 
        int guessCount = 0; // counter of number of guesses

                            // Task 2: Add a loop that keeps looping until guess matches magic number.

        // Step 4: A while loop to keep asking for guesses until the user gets it right
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            guessCount++; // Increment guess count

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it! It took you {guessCount} guesses.");
            }
        }
    }
}