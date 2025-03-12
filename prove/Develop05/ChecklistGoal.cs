public class ChecklistGoal : Goal
{
    public int TimesToComplete { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, int points, int timesToComplete, int bonus) : base(name, points)
    {
        TimesToComplete = timesToComplete;
        Bonus = bonus;
    }

    public override void RecordProgress()
    {
        Progress += Points; // Increase progress by points each time
        if (Progress >= TimesToComplete * Points)
        {
            Progress += Bonus; // Add bonus when checklist is complete
        }
    }

    public override string ToFileFormat()
    {
        return $"{Name}|{Points}|ChecklistGoal|{Progress}|{TimesToComplete}|{Bonus}";
    }
}
