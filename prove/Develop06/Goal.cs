using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Public properties to expose fields
    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();
    public int GetPoints() => _points;
}