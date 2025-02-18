using System;
using System.Threading;

// Inheritance: The base class MindfulnessActivity is extended by BreathingActivity, ReflectionActivity,
// and ListingActivity. Each subclass provides its specific implementation of the ExecuteActivity() method.

public abstract class MindfulnessActivity
{
    protected int Duration { get; set; }

    public void StartActivity()
    {
        // Common starting message
        ShowStartingMessage();

        // Set duration
        Console.Write("Enter the duration for the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());

        // Pause before starting
        Console.WriteLine("Preparing to start...");
        Thread.Sleep(2000); // Pause for 2 seconds

        // Execute specific activity behavior
        ExecuteActivity();

        // Common ending message
        ShowEndingMessage();
    }

    // Show a generic start message for all activities
    private void ShowStartingMessage()
    {
        Console.WriteLine("Starting activity...");
        Console.WriteLine("This activity will help you relax and reflect.");
        Thread.Sleep(1000); // Short pause
    }

    // Show a generic end message for all activities
    private void ShowEndingMessage()
    {
        Console.WriteLine("Great job! You've completed the activity.");
        Thread.Sleep(2000); // Pause for 2 seconds
    }

    // Abstract method to be implemented by subclasses for specific behavior
    protected abstract void ExecuteActivity();

    // Helper method to simulate a pause with a spinner animation
    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000); // Wait for 1 second
        }
        Console.WriteLine();
    }
}
