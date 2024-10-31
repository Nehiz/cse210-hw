public class Cycling : Activity
{
    private double speed; // in mph

    public Cycling(DateTime date, int minutes, double speed) 
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * Minutes) / 60; // Distance in miles
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed; // Pace in min/mile
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Speed: {speed:F1} mph, Pace: {GetPace():F1} min per mile";
    }
}