abstract class Goal
{
    public decimal TargetAmount { get; set; }
    public decimal CurrentAmount { get; set; }
    public DateTime Deadline { get; set; }

    public Goal(decimal targetAmount, DateTime deadline)
    {
        TargetAmount = targetAmount;
        Deadline = deadline;
        CurrentAmount = 0;
    }

    public abstract string CheckProgress();
}

class SavingsGoal : Goal
{
    public SavingsGoal(decimal targetAmount, DateTime deadline) : base(targetAmount, deadline) { }

    public override string CheckProgress()
    {
        return $"Savings Goal: {CurrentAmount}/{TargetAmount} saved. Deadline: {Deadline.ToShortDateString()}";
    }
}

class DebtRepaymentGoal : Goal
{
    public DebtRepaymentGoal(decimal targetAmount, DateTime deadline) : base(targetAmount, deadline) { }

    public override string CheckProgress()
    {
        return $"Debt Repayment: {CurrentAmount}/{TargetAmount} paid off. Deadline: {Deadline.ToShortDateString()}";
    }
}
