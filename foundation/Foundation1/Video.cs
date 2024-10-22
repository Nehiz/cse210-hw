using System; 
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }  // Length in seconds
    private List<Comment> _comments;


    // Constructor
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        _comments = new List<Comment>();
    }

    // method to get the number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to display the video details
    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");

        // Method to Display comments
        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            comment.Display();
        }
    }

}

// this class will tracks the video's title, author, and length.
// it will has a list of comment objects to store the comments for the video.
// it includes a method to get the number of comments, and a method to add a comment to the list.
// it also includes a method to display the video details and comments.