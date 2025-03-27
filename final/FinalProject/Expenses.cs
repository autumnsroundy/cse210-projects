class Expense : Transaction
{
    public string PaymentMethod { get; private set; }

    public Expense(decimal amount, DateTime date, string category, string description, string paymentMethod)
        : base(amount, date, category, description)
    {
        PaymentMethod = paymentMethod;
    }

    public override string GetTransactionDetails()
    {
        return $"Expense: {Amount:C} paid via {PaymentMethod} on {Date.ToShortDateString()} ({Category}) - {Description}";
    }
}
