using System.Collections.Generic;
using System.Linq;

class Budget
{
    public List<Income> Incomes { get; private set; } = new List<Income>();
    public List<Expense> Expenses { get; private set; } = new List<Expense>();

    public void AddIncome(Income income)
    {
        Incomes.Add(income);
    }

    public void AddExpense(Expense expense)
    {
        Expenses.Add(expense);
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
}
