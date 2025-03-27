using System;

abstract class Transaction
{
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Category { get; private set; }
    public string Description { get; private set; }

    public Transaction(decimal amount, DateTime date, string category, string description)
    {
        Amount = amount;
        Date = date;
        Category = category;
        Description = description;
    }

    public abstract string GetTransactionDetails();
}
