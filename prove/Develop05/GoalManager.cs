using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals;
    public int TotalPoints { get; private set; }

    public GoalManager()
    {
        goals = new List<Goal>();
        TotalPoints = 0;
    }

    // Add a new goal to the list
    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    // Display all goals and their completion status
    public void DisplayGoals()
    {
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.ToString());
        }
    }

    // Record completion of a goal by its name
    public void RecordGoal(string goalName)
    {
        foreach (Goal goal in goals)
        {
            if (goal.Name == goalName)
            {
                goal.RecordProgress();
                TotalPoints += goal.Points;
                Console.WriteLine($"Goal '{goalName}' recorded. {goal.Points} points awarded.");
                break;
            }
        }
    }

    // Save goals to a file
    public void SaveGoals(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(TotalPoints);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.ToFileFormat());
            }
        }
    }

    // Load goals from a file
    public void LoadGoals(string fileName)
    {
        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                TotalPoints = int.Parse(reader.ReadLine());
                goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var goalData = line.Split('|');
                    string name = goalData[0];
                    int points = int.Parse(goalData[1]);
                    string type = goalData[2];

                    Goal goal = null;
                    if (type == "SimpleGoal")
                    {
                        goal = new SimpleGoal(name, points);
                    }
                    else if (type == "EternalGoal")
                    {
                        goal = new EternalGoal(name, points);
                    }
                    else if (type == "ChecklistGoal")
                    {
                        int timesCompleted = int.Parse(goalData[3]);
                        int timesToComplete = int.Parse(goalData[4]);
                        int bonus = int.Parse(goalData[5]);
                        goal = new ChecklistGoal(name, points, timesToComplete, bonus);
                    }

                    if (goal != null)
                    {
                        goals.Add(goal);
                    }
                }
            }
        }
    }
}
