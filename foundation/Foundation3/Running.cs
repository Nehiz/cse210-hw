public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int minutes, double distance) 
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / Minutes) * 60; // Speed in mph
    }

    public override double GetPace()
    {
        return Minutes / distance; // Pace in min/mile
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}