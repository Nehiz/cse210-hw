class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "List things you are grateful for.",
        "List people who make you happy.",
        "List your favorite memories.",
        "list your favorite foods.",
        "List your favorite things to do."
    };

    public ListingActivity(int duration)
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can.", duration) { }
    
    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("Start list. Type 'done' to finish: ");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;  // fix case sensistivity for 'done'
            items.Add(input);
            _count++;
        }
        return items;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        List<string> userItems = GetListFromUser();
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }
}