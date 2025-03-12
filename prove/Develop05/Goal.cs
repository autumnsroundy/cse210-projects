public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public int Progress { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        Progress = 0;
    }

    public abstract void RecordProgress();

    public abstract string ToFileFormat();

    public override string ToString()
    {
        return $"{Name}: {Progress}/{Points} points";
    }
}
