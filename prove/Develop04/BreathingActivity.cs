using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    protected override void ExecuteActivity()
    {
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Thread.Sleep(1000); // Short pause

        for (int i = 0; i < Duration / 4; i++) // Each breath cycle is 4 seconds
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3); // Simulating the breath pause with a spinner
            Console.WriteLine("Breathe out...");
            ShowSpinner(3); // Simulating the breath pause with a spinner
        }
    }
}
