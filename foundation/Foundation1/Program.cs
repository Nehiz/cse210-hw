using System;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        // Create Video objects

        Video video1 = new Video("Introduction to C#", "John Smith", 120);
        Video video2 = new Video("Mastering Abstraction", "Jane Smith", 180);
        Video video3 = new Video("OOP in C# Programming", "Alice Smith", 100);

        // Add Comments to Video1
        video1.AddComment(new Comment("Mike", "Great video!"));
        video1.AddComment(new Comment("Anna", "Awesome video, Thanks!"));
        video1.AddComment(new Comment("Sammy", "I really like this video!"));

        // Add Comments to Video2
        video2.AddComment(new Comment("Lucy", "Loved the examples!"));
        video2.AddComment(new Comment("Tom", "Simple to understand!"));
        video2.AddComment(new Comment("Rachel", "Easy to follow!"));

        // Add Comments to Video3
        video3.AddComment(new Comment("Sally", "I really enjoyed the content of the video!"));
        video3.AddComment(new Comment("David", "I love how you simplified the code!"));
        video3.AddComment(new Comment("Lisa", "I can't wait to see the next video!"));

        // store videos in a list
        List<Video> videos = new List<Video> {video1, video2, video3};

        // Display all the video details
        foreach (var video in videos)
        {
            video.Display( );
            Console.WriteLine(); // print a blank line between videos
        }
        
    }
}

// Three video objects are created with appropriate details ( title, author, and length ).
// Each has three Comment objects attached to it.
// The videos are stored in a List<Video>, and a loop is used to display the details of each video.