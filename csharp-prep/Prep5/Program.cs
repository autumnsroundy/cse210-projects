using System;

class Program
{
    // Display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    // Prompt the user for their name and return it as a string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    // Prompt the user for their favorite number and return it as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    // Square the number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }
    // Display the result (name and squared number)
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
    static void Main()
    {
        // Call the functions in the required sequence
        DisplayWelcome();
        
        // Get the user's name and favorite number
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        
        // Square the favorite number
        int squaredNumber = SquareNumber(favoriteNumber);
        
        // Display the result
        DisplayResult(userName, squaredNumber);
    }
}
