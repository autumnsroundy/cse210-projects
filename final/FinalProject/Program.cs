using System;

class Program
{
    static void Main()
    {
        // Create User
        User user = new User("Autumn");

        // Add Incomes
        user.Budget.AddIncome(new Income(2000, DateTime.Now, "Salary", "Monthly paycheck", "Company XYZ"));
        user.Budget.AddIncome(new Income(500, DateTime.Now, "Freelance", "Freelance project payment", "Upwork"));

        // Add Expenses
        user.Budget.AddExpense(new Expense(800, DateTime.Now, "Rent", "Apartment rent", "Credit Card"));
        user.Budget.AddExpense(new Expense(200, DateTime.Now, "Groceries", "Supermarket shopping", "Debit Card"));

        // Set Goals
        user.AddGoal(new SavingsGoal(5000, DateTime.Now.AddMonths(6)));
        user.AddGoal(new DebtRepaymentGoal(2000, DateTime.Now.AddMonths(3)));

        // Generate Reports
        ReportGenerator report = new ReportGenerator(user.Budget.Incomes, user.Budget.Expenses, user.Goals);
        Console.WriteLine(user.GetFinancialSummary());
        Console.WriteLine(report.GenerateIncomeReport());
        Console.WriteLine(report.GenerateSpendingReport());
        Console.WriteLine(report.GenerateGoalProgressReport());
    }
}

