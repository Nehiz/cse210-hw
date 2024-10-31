class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent()
    {
        // Points are awarded every time the event is recorded
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation() => $"[ ] {_name} - Points: {_points} (Eternal)";
}