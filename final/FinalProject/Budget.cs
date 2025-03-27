using System.Collections.Generic;
using System.Linq;

class Budget
{
    public List<Transaction> Transactions { get; private set; } = new List<Transaction>();

    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }

    public decimal GetRemainingBudget(decimal monthlyBudget)
    {
        decimal totalExpenses = Transactions.OfType<Expense>().Sum(e => e.Amount);
        return monthlyBudget - totalExpenses;
    }
}
