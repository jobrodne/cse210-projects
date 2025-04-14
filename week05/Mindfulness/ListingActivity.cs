using System;
using System.Collections.Generic;

public class ListingActivity : MindfulnessActivity
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