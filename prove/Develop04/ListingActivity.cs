using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    protected override void ExecuteActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine("This activity will help you reflect on the good things in your life by listing as many things as you can.");
        Console.WriteLine(prompt);

        Thread.Sleep(1000); // Short pause
        ShowSpinner(3); // Simulate thinking time

        // Start listing items
        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("List an item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
                count++;
        }

        Console.WriteLine($"You listed {count} items.");
    }
}
