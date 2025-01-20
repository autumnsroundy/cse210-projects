using System;
class Program
{
    static void Main()
    {
        // Creating Job instances
        Job job1 = new Job("Wildlife Photographer", "National Geographic", 2019, 2022);
        Job job2 = new Job("Conservation Photographer", "NOAA", 2022, 2023);

        Resume myResume = new Resume("Autumn Roundy");
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Display the resume and job details
        myResume.Display();
    }
}
