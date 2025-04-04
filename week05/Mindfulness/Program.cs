using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int duration;

    public void DisplayStartMessage(string name, string description)
    {
        Console.WriteLine($"\n{name} Activity");
        Console.WriteLine(description);
        Console.Write("Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed {duration} seconds of mindfulness activity.");
        ShowSpinner(3);
    }

    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    public abstract void Run();
}

class BreathingActivity : MindfulnessActivity
{
    public override void Run()
    {
        DisplayStartMessage("Breathing", "This activity will help you relax by walking you through breathing in and out slowly.");

        for (int i = 0; i < duration; i += 6)
        {
            Console.Write("Breathe in... ");
            PauseWithCountdown(3);
            Console.Write("Breathe out... ");
            PauseWithCountdown(3);
        }

        DisplayEndMessage();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time you stood up for someone else.",
        "Think of a time you did something really difficult.",
        "Think of a time you helped someone in need.",
        "Think of a time you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How did you feel afterward?",
        "What could you learn from this experience?"
    };

    public override void Run()
    {
        DisplayStartMessage("Reflection", "This activity will help you reflect on times you showed strength and resilience.");

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine($"\n{prompt}");
        ShowSpinner(3);

        int secondsPerQuestion = duration / questions.Length;
        foreach (string question in questions)
        {
            Console.WriteLine($"\n> {question}");
            ShowSpinner(secondsPerQuestion);
        }

        DisplayEndMessage();
    }
}

class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped recently?"
    };

    public override void Run()
    {
        DisplayStartMessage("Listing", "This activity will help you reflect on the good things in your life.");

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine($"\nList responses to the following prompt:\n> {prompt}");
        Console.WriteLine("Start listing after the countdown...");
        PauseWithCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
            {
                items.Add("item");
            }
        }

        Console.WriteLine($"You listed {items.Count} items!");
        DisplayEndMessage();
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();
            MindfulnessActivity activity = null;

            switch (input)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectionActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": return;
                default:
                    Console.WriteLine("Invalid option.");
                    Thread.Sleep(1000);
                    continue;
            }

            Console.Clear();
            activity.Run();
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}