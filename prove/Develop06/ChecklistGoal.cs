class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetStringRepresentation()
    {
        return $"[{(_amountCompleted >= _target ? "X" : " ")}] {_name} - Points: {_points}, Completed {_amountCompleted}/{_target}, Bonus: {_bonus}";
    }

    public int CalculateBonus()
    {
        return IsComplete() ? _bonus : 0;
    }

    public int AmountCompleted => _amountCompleted;
    public int Target => _target;
}