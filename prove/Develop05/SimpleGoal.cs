public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordProgress()
    {
        Progress = Points; // Mark goal as complete
    }

    public override string ToFileFormat()
    {
        return $"{Name}|{Points}|SimpleGoal|{Progress}"; // Save progress
    }
}