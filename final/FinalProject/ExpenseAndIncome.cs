class Income : Transaction
{
    public string Source { get; set; }

    public Income(decimal amount, DateTime date, string category, string description, string source)
        : base(amount, date, category, description)
    {
        Source = source;
    }

    public override string GetTransactionDetails()
    {
        return $"Income: {Amount} from {Source} on {Date.ToShortDateString()} ({Category}) - {Description}";
    }
}

class Expense : Transaction
{
    public string PaymentMethod { get; set; }

    public Expense(decimal amount, DateTime date, string category, string description, string paymentMethod)
        : base(amount, date, category, description)
    {
        PaymentMethod = paymentMethod;
    }

    public override string GetTransactionDetails()
    {
        return $"Expense: {Amount} paid via {PaymentMethod} on {Date.ToShortDateString()} ({Category}) - {Description}";
    }
}
