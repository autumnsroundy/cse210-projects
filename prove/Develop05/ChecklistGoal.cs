public class ChecklistGoal : Goal
{
    public int TimesToComplete { get; set; }
    public int TimesCompleted { get; set; } // Track progress
    public int Bonus { get; set; }

    public ChecklistGoal(string name, int points, int timesToComplete, int bonus) : base(name, points)
    {
        TimesToComplete = timesToComplete;
        Bonus = bonus;
        TimesCompleted = 0; // Ensure tracking
    }

    public override void RecordProgress()
    {
        if (TimesCompleted < TimesToComplete) 
        {
            TimesCompleted++;
            Progress += Points; // Add points per completion
        }

        if (TimesCompleted == TimesToComplete)
        {
            Progress += Bonus; // Add bonus when fully completed
        }
    }

    public override string ToFileFormat()
    {
        return $"{Name}|{Points}|ChecklistGoal|{TimesCompleted}|{TimesToComplete}|{Bonus}"; // Save progress
    }

    public override string ToString()
    {
        return $"{Name}: {TimesCompleted}/{TimesToComplete} completed, {Progress} points"; // Display correctly
    }
}