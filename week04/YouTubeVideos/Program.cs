using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public string GetComment()
    {
        return $"{CommenterName}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> Comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumComments()
    {
        return Comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"  - {comment.GetComment()}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("Intro to C#", "CodeMaster", 300);
        Video video2 = new Video("Understanding OOP", "DevAcademy", 420);
        Video video3 = new Video("C# Lists Explained", "LearnFast", 360);

        // Add comments to video1
        video1.AddComment(new Comment("Kari", "Great video!"));
        video1.AddComment(new Comment("Job", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Cara", "Can you cover classes next?"));

        // Add comments to video2
        video2.AddComment(new Comment("David", "Really clear explanation."));
        video2.AddComment(new Comment("Cindy", "Loved the examples."));
        video2.AddComment(new Comment("Joseph", "I finally get it!"));

        // Add comments to video3
        video3.AddComment(new Comment("Fegens", "Awesome list tutorial."));
        video3.AddComment(new Comment("Lever", "Please make one on dictionaries."));
        video3.AddComment(new Comment("Evens", "Thanks, I needed this!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display all video info
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}