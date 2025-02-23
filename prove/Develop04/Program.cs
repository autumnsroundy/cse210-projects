using System;
using System.IO;
// Stretch challenge this week : Implement a log to count how many times each activity was performed. 
class Program
{
    // File path to store the count
    private static string logFilePath = "activity_log.txt";

    static void Main(string[] args)
    {
        // Load activity counts from file (if file exists)
        int breathingCount = 0, reflectionCount = 0, listingCount = 0;

        if (File.Exists(logFilePath))
        {
            string[] lines = File.ReadAllLines(logFilePath);
            if (lines.Length >= 3)
            {
                breathingCount = int.Parse(lines[0]);
                reflectionCount = int.Parse(lines[1]);
                listingCount = int.Parse(lines[2]);
            }
        }

        // Display activity options
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Please choose an activity:");

        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        int choice = int.Parse(Console.ReadLine());

        MindfulnessActivity activity = null;

        switch (choice)
        {
            case 1:
                activity = new BreathingActivity();
                breathingCount++; // Increment breathing activity count
                break;
            case 2:
                activity = new ReflectionActivity();
                reflectionCount++; // Increment reflection activity count
                break;
            case 3:
                activity = new ListingActivity();
                listingCount++; // Increment listing activity count
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting.");
                return;
        }

        activity.StartActivity();

        // Print out the current activity count after completing the activity
        Console.WriteLine("\nActivity Log:");
        Console.WriteLine($"Breathing Activity performed: {breathingCount} times");
        Console.WriteLine($"Reflection Activity performed: {reflectionCount} times");
        Console.WriteLine($"Listing Activity performed: {listingCount} times");

        // Save updated counts to the file
        File.WriteAllLines(logFilePath, new string[]
        {
            breathingCount.ToString(),
            reflectionCount.ToString(),
            listingCount.ToString()
        });
    }
}
