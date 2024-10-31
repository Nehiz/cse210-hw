public class Swimming : Activity
{
    private int laps; // Number of laps

    public Swimming(DateTime date, int minutes, int laps) 
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0; // Distance in km
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60; // Speed in kph
    }

    public override double GetPace()
    {
        return Minutes / GetDistance(); // Pace in min/km
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Distance: {GetDistance() * 0.621371:F1} miles, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F1} min per km";
    }
}