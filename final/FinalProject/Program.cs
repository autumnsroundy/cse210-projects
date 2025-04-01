using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create User
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        User user = new User(userName);

        // Load previous transactions
        user.Budget.LoadFromFile();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Finance Tracker Menu:");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. Set Financial Goals");
            Console.WriteLine("4. Update Goal Progress");
            Console.WriteLine("5. View Reports");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddIncome(user);
                    break;
                case "2":
                    AddExpense(user);
                    break;
                case "3":
                    SetGoal(user);
                    break;
                case "4":
                    UpdateGoalProgress(user);
                    break;
                case "5":
                    DisplayReports(user);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        // Save transactions before exiting
        user.Budget.SaveToFile();

        Console.WriteLine("Thank you for using the Finance Tracker!");
    }

    static void AddIncome(User user)
    {
        Console.Write("Enter income amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter income category: ");
        string category = Console.ReadLine();

        Console.Write("Enter income description: ");
        string description = Console.ReadLine();

        Console.Write("Enter income source (e.g., Salary, Freelance, Business): ");
        string source = Console.ReadLine();

        user.Budget.AddIncome(new Income(amount, DateTime.Now, category, description, source));

        Console.WriteLine("Income added successfully!\nPress Enter to continue...");
        Console.ReadLine();
    }

    static void AddExpense(User user)
    {
        Console.Write("Enter expense amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter expense category: ");
        string category = Console.ReadLine();

        Console.Write("Enter expense description: ");
        string description = Console.ReadLine();

        Console.Write("Enter payment method (e.g., Cash, Credit Card, Debit Card): ");
        string paymentMethod = Console.ReadLine();

        user.Budget.AddExpense(new Expense(amount, DateTime.Now, category, description, paymentMethod));

        Console.WriteLine("Expense added successfully!\nPress Enter to continue...");
        Console.ReadLine();
    }

    static void SetGoal(User user)
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Savings Goal");
        Console.WriteLine("2. Debt Repayment Goal");
        Console.Write("Choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter target amount: ");
        decimal targetAmount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter number of months to achieve this goal: ");
        int months = int.Parse(Console.ReadLine());
        DateTime deadline = DateTime.Now.AddMonths(months);

        if (choice == "1")
            user.AddGoal(new SavingsGoal(targetAmount, deadline));
        else if (choice == "2")
            user.AddGoal(new DebtRepaymentGoal(targetAmount, deadline));
        else
            Console.WriteLine("Invalid selection.");

        Console.WriteLine("Goal added successfully!\nPress Enter to continue...");
        Console.ReadLine();
    }

    static void UpdateGoalProgress(User user)
    {
        if (user.Goals.Count == 0)
        {
            Console.WriteLine("No financial goals set. Please add a goal first.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Select a goal to update progress:");
        for (int i = 0; i < user.Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {user.Goals[i].CheckProgress()}");
        }

        Console.Write("Enter goal number: ");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > user.Goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            Console.ReadLine();
            return;
        }

        Goal selectedGoal = user.Goals[choice - 1];

        Console.Write("Enter amount to add towards this goal: ");
        decimal amount;
        if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount.");
            Console.ReadLine();
            return;
        }

        selectedGoal.CurrentAmount += amount;

        Console.WriteLine($"Progress updated!\n{selectedGoal.CheckProgress()}");
        Console.ReadLine();
    }

    static void DisplayReports(User user)
    {
        Console.Clear();
        ReportGenerator report = new ReportGenerator(user.Budget.Incomes, user.Budget.Expenses, user.Goals);

        Console.WriteLine(user.GetFinancialSummary());
        Console.WriteLine(report.GenerateIncomeReport());
        Console.WriteLine(report.GenerateSpendingReport());
        Console.WriteLine(report.GenerateGoalProgressReport());

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}
