using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create User
        User user = new User("Autumn");

        // Add Transactions
        user.Budget.AddTransaction(new Income(2000, DateTime.Now, "Salary", "Monthly paycheck", "Company XYZ"));
        user.Budget.AddTransaction(new Expense(500, DateTime.Now, "Rent", "Apartment rent", "Credit Card"));
        user.Budget.AddTransaction(new Expense(150, DateTime.Now, "Groceries", "Supermarket shopping", "Debit Card"));

        // Set Goals
        user.AddGoal(new SavingsGoal(5000, DateTime.Now.AddMonths(6)));
        user.AddGoal(new DebtRepaymentGoal(2000, DateTime.Now.AddMonths(3)));

        // Generate Reports
        ReportGenerator report = new ReportGenerator(user.Budget.Transactions, user.Goals);
        Console.WriteLine(user.GetFinancialSummary());
        Console.WriteLine(report.GenerateSpendingReport());
        Console.WriteLine(report.GenerateGoalProgressReport());
    }
}
