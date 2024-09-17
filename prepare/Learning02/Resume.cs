using System;
using System.Collections.Generic;

public class Resume
{
    // Member variable for the person's name
    public string _name;

    //member variable to store a list of jobs
    public List<Job> _jobs = new List<Job>();

    // Method to display the resume details
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Loop through each job and display its details
        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}