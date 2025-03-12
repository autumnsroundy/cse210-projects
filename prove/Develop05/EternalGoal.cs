public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordProgress()
    {
        Progress += Points; // Eternal goals accumulate points
    }

    public override string ToFileFormat()
    {
        return $"{Name}|{Points}|EternalGoal";
    }
}
