class BreathingActivity : Activity
{
    public BreathingActivity(int duration)
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration) {}

    public override void Run()
    {
        DisplayStartingMessage();
        /*int cycles = _duration / 6;  // each cycle stays for appropriately 6 seconds (3 for inhale, 3 for exhale)
        for (int i = 0; i < _duration; i++)
       
        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3);
            Console.WriteLine("Now breathe out...");
            ShowSpinner(3);
        }
        DisplayEndingMessage(); */

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3);
            Console.WriteLine("Now breathe out...");
            ShowSpinner(3);
        }

        DisplayEndingMessage();
    }
    
}