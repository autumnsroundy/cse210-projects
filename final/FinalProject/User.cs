using System.Collections.Generic;

class User
{
    public string Name { get; set; }
    public Budget Budget { get; private set; } = new Budget();
    public List<Goal> Goals { get; private set; } = new List<Goal>();

    public User(string name)
    {
        Name = name;
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public string GetFinancialSummary()
    {
        return $"User: {Name}, Remaining Budget: {Budget.GetRemainingBudget(1000)}"; // Example budget limit
    }
}
