using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Budget
{
    public List<Income> Incomes { get; private set; } = new List<Income>();
    public List<Expense> Expenses { get; private set; } = new List<Expense>();

    public void AddIncome(Income income)
    {
        Incomes.Add(income);
        SaveToFile();
    }

    public void AddExpense(Expense expense)
    {
        Expenses.Add(expense);
        SaveToFile();
    }

    public decimal GetTotalIncome()
    {
        return Incomes.Sum(i => i.Amount);
    }

    public decimal GetTotalExpenses()
    {
        return Expenses.Sum(e => e.Amount);
    }

    public decimal GetRemainingBudget(decimal monthlyBudget)
    {
        return monthlyBudget - GetTotalExpenses();
    }

    // Save transactions to a file
    public void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter("transactions.txt"))
        {
            foreach (var income in Incomes)
            {
                writer.WriteLine($"Income,{income.Amount},{income.Date},{income.Category},{income.Description},{income.Source}");
            }
            foreach (var expense in Expenses)
            {
                writer.WriteLine($"Expense,{expense.Amount},{expense.Date},{expense.Category},{expense.Description},{expense.PaymentMethod}");
            }
        }
    }

    // Load transactions from a file
    public void LoadFromFile()
    {
        if (File.Exists("transactions.txt"))
        {
            string[] lines = File.ReadAllLines("transactions.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0] == "Income")
                {
                    AddIncome(new Income(decimal.Parse(parts[1]), DateTime.Parse(parts[2]), parts[3], parts[4], parts[5]));
                }
                else if (parts[0] == "Expense")
                {
                    AddExpense(new Expense(decimal.Parse(parts[1]), DateTime.Parse(parts[2]), parts[3], parts[4], parts[5]));
                }
            }
        }
    }
}
