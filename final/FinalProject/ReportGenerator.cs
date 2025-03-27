using System;
using System.Collections.Generic;
using System.Linq;

class ReportGenerator
{
    public List<Transaction> Transactions { get; set; }
    public List<Goal> Goals { get; set; }

    public ReportGenerator(List<Transaction> transactions, List<Goal> goals)
    {
        Transactions = transactions;
        Goals = goals;
    }

    public string GenerateSpendingReport()
    {
        var expenseTotal = Transactions.OfType<Expense>().Sum(e => e.Amount);
        return $"Total Spending: {expenseTotal}";
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
