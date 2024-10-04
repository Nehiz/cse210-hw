public class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        // Initializing with some default prompts
        _prompts = new List<string>
        {
            "What made you happy today?",
            "What are you grateful for?",
            "Describe a challenge you overcame today.",
            "What are your goals for tomorrow?",
            "How are you feeling right now?"
        };
    }


    // Method to get a random prompt
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}