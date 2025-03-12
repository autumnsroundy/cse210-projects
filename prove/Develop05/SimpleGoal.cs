public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordProgress()
    {
        Progress = Points; // Simple goal is completed in one step
    }

    public override string ToFileFormat()
    {
        return $"{Name}|{Points}|SimpleGoal";
    }
}
