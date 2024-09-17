using System;

public class Job
{
    //Member variables to store job details
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // method to display the job details
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}