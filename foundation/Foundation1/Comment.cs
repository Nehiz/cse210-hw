public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    // Constructor
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    // Method to display the comment details
    public void Display()
    {
        Console.WriteLine($"{Name}: {Text}");
    }
}

// This class encapsulates the details of a comment, such as the commenter's name and text of the comment.
// It also includes a method- Display( ) to display the comment details.