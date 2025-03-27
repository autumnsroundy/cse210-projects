using System;

abstract class Transaction
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }

    public Transaction(decimal amount, DateTime date, string category, string description)
    {
        Amount = amount;
        Date = date;
        Category = category;
        Description = description;
    }

    public abstract string GetTransactionDetails();
}
