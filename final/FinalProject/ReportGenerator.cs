using System;
using System.Collections.Generic;
using System.Linq;

class ReportGenerator
{
    public List<Income> Incomes { get; set; }
    public List<Expense> Expenses { get; set; }
    public List<Goal> Goals { get; set; }

    public ReportGenerator(List<Income> incomes, List<Expense> expenses, List<Goal> goals)
    {
        Incomes = incomes;
        Expenses = expenses;
        Goals = goals;
    }

    public string GenerateSpendingReport()
    {
        var totalExpenses = Expenses.Sum(e => e.Amount);
        return $"Total Spending: {totalExpenses:C}";
    }

    public string GenerateIncomeReport()
    {
        var totalIncome = Incomes.Sum(i => i.Amount);
        return $"Total Income: {totalIncome:C}";
    }

    public string GenerateGoalProgressReport()
    {
        string report = "Goal Progress:\n";
        foreach (var goal in Goals)
        {
            report += goal.CheckProgress() + "\n";
        }
        return report;
    }
}
