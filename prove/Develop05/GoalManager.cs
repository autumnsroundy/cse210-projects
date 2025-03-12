using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals;
    public int TotalPoints { get; private set; }
    
    // Property to calculate the level based on TotalPoints
    public int Level
    {
        get
        {
            // Calculate level based on total points (e.g., 1000 points = level 1, 2000 points = level 2, etc.)
            return TotalPoints / 1000 + 1; // Increase level every 1000 points
        }
    }

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
                int previousPoints = goal.Progress; // Store previous progress before update

                goal.RecordProgress(); // Update the goal's progress

                int newPoints = goal.Progress - previousPoints; // Calculate points earned
                TotalPoints += newPoints; // Update total points correctly

                Console.WriteLine($"Goal '{goalName}' recorded. {newPoints} points awarded.");
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
                string totalPointsLine = reader.ReadLine();

                if (string.IsNullOrWhiteSpace(totalPointsLine) || !int.TryParse(totalPointsLine, out int parsedTotalPoints))
                {
                    TotalPoints = 0; // Default if missing
                }
                else
                {
                    TotalPoints = parsedTotalPoints;
                }

                goals.Clear();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var goalData = line.Split('|');
                    if (goalData.Length < 3) continue;

                    string name = goalData[0];
                    if (!int.TryParse(goalData[1], out int points)) continue;

                    string type = goalData[2];

                    Goal goal = null;
                    if (type == "SimpleGoal" && goalData.Length >= 4)
                    {
                        if (int.TryParse(goalData[3], out int progress))
                        {
                            goal = new SimpleGoal(name, points) { Progress = progress };
                        }
                    }
                    else if (type == "EternalGoal" && goalData.Length >= 4)
                    {
                        if (int.TryParse(goalData[3], out int progress))
                        {
                            goal = new EternalGoal(name, points) { Progress = progress };
                        }
                    }
                    else if (type == "ChecklistGoal" && goalData.Length >= 6)
                    {
                        if (int.TryParse(goalData[3], out int timesCompleted) &&
                            int.TryParse(goalData[4], out int timesToComplete) &&
                            int.TryParse(goalData[5], out int bonus))
                        {
                            var checklistGoal = new ChecklistGoal(name, points, timesToComplete, bonus)
                            {
                                TimesCompleted = timesCompleted,
                                Progress = timesCompleted * points // Ensure progress is correctly restored
                            };
                            goal = checklistGoal;
                        }
                    }

                    if (goal != null)
                    {
                        goals.Add(goal);
                    }
                }
            }
        }
        else
        {
            TotalPoints = 0; // Default to 0 if file doesn't exist
        }
    }

    // Reset all points and progress
    public void ResetPoints()
    {
        TotalPoints = 0;
        foreach (var goal in goals)
        {
            goal.ResetProgress(); // Ensure each goal properly resets
        }
    }
}
