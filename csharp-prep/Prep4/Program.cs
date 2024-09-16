using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type o when finished. ");

        // Loop to accept numbers until the user enters 0
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        // Core Requirement 1: Calculate sum
        int sum = numbers.Sum();
        Console.WriteLine($"the sum is: {sum}");

        // Core Requirement 2: Calculate average
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");

        // Core Requirement 3: Find the largest number
        int max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");

        //Stretch Challenge 1: Find the smallest positive number
        int smallestPositive = numbers.Where(n => n > 0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        //Stretch Challenge 2: Sort the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}