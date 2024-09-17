using System;

class Program
{
    static void Main(string[] args)
    {
        // Create first job instance
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // Create second job instance
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        // Create a resume instance
        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        // Add jobs to the resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // display the resume
        myResume.DisplayResume();

        //  Display job details using the Display method
        // job1.DisplayJobDetails();
        // job2.DisplayJobDetails();
    }
}