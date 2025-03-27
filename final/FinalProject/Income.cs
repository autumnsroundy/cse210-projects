class Income : Transaction
{
    public string Source { get; private set; }

    public Income(decimal amount, DateTime date, string category, string description, string source)
        : base(amount, date, category, description)
    {
        Source = source;
    }

    public override string GetTransactionDetails()
    {
        return $"Income: {Amount:C} from {Source} on {Date.ToShortDateString()} ({Category}) - {Description}";
    }
}
