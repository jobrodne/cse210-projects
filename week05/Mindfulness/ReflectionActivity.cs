using System;

public class ReflectionActivity : MindfulnessActivity
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