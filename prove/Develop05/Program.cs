public class Program

{
    static void Main()
    {
        GoalManager goalManager = new GoalManager();

        // Load saved goals from file if it exists
        goalManager.LoadGoals("goals.txt");

        while (true)
        {
            // Display menu
            Console.Clear();
            Console.WriteLine("Welcome to the Eternal Quest Goal Manager!");
            Console.WriteLine($"Total Points: {goalManager.TotalPoints}");
            Console.WriteLine($"Current Level: {goalManager.Level}");
            Console.WriteLine("1. Add a Goal");
            Console.WriteLine("2. Display Goals");
            Console.WriteLine("3. Record Goal Progress");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Reset Points");
            Console.WriteLine("7. Exit");
            Console.Write("Please select an option (1-7): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Add a new goal
                    AddGoal(goalManager);
                    break;
                case "2":
                    // Display all goals
                    goalManager.DisplayGoals();
                    Console.WriteLine($"Total Points: {goalManager.TotalPoints}");
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;
                case "3":
                    // Record goal progress
                    RecordGoalProgress(goalManager);
                    break;
                case "4":
                    // Save goals to file
                    goalManager.SaveGoals("goals.txt");
                    Console.WriteLine("Goals saved successfully!");
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;
                case "5":
                    // Load goals from file
                    goalManager.LoadGoals("goals.txt");
                    Console.WriteLine("Goals loaded successfully!");
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;
                case "6":
                    // Reset points and progress
                    goalManager.ResetPoints();
                    Console.WriteLine("Points and progress have been reset.");
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;
                case "7":
                    // Exit the program
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    // Method to add a new goal
    static void AddGoal(GoalManager goalManager)
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Please select an option (1-3): ");
        string goalType = Console.ReadLine();

        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter the points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            goalManager.AddGoal(new SimpleGoal(name, points));
        }
        else if (goalType == "2")
        {
            goalManager.AddGoal(new EternalGoal(name, points));
        }
        else if (goalType == "3")
        {
            Console.Write("Enter the number of times to complete the goal: ");
            int timesToComplete = int.Parse(Console.ReadLine());

            Console.Write("Enter the bonus points for completing the checklist: ");
            int bonus = int.Parse(Console.ReadLine());

            goalManager.AddGoal(new ChecklistGoal(name, points, timesToComplete, bonus));
        }

        goalManager.SaveGoals("goals.txt"); // Autosave after adding the goal
        Console.WriteLine("Goal added and saved successfully!");
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }

    // Method to record goal progress
    static void RecordGoalProgress(GoalManager goalManager)
    {
        Console.Write("Enter the name of the goal you want to record progress for: ");
        string goalName = Console.ReadLine();

        goalManager.RecordGoal(goalName);

        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}
