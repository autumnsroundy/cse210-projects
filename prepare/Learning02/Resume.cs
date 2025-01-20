using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    private string _name;
    private List<Job> _jobs;

    // Constructor to initialize resume with name and an empty list of jobs
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();  // Initialize an empty list of jobs
    }

    // Method to add a job to the resume
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    // Display method to print resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.Display();  // Call the Display method of each Job object
        }
    }
}
