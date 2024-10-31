public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int Minutes => _minutes;

    public abstract double GetDistance(); // Abstract method for distance
    public abstract double GetSpeed();    // Abstract method for speed
    public abstract double GetPace();     // Abstract method for pace

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_minutes} min) - Distance: {GetDistance()}";
    }
}
