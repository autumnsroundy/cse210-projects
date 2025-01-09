using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Step 1: Initialize an empty list to store numbers
        List<int> numbers = new List<int>();

        // Step 2: Collect numbers from the user until they enter 0
        while (true)
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());

            if (num == 0)
                break; // Stop if the user enters 0

            numbers.Add(num); // Append the number to the list
        }

        // Step 3: Compute the sum of the numbers in the list
        int sum = numbers.Sum();

        // Step 4: Compute the average of the numbers in the list
        double average = numbers.Count > 0 ? sum / (double)numbers.Count : 0;

        // Step 5: Find the largest number in the list
        int largest = numbers.Count > 0 ? numbers.Max() : 0;

        // Step 6: Output the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}
