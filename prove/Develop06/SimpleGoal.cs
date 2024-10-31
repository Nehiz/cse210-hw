class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true; // Mark goal as complete
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation() => $"{(_isComplete ? "[X]" : "[ ]")} {_name} - Points: {_points}";
}