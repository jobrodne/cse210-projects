using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;

        // Add example goals
        goals.Add(new SimpleGoal("Run a marathon", "Complete a full marathon", 1000));
        goals.Add(new EternalGoal("Read scriptures", "Daily scripture reading", 100));
        goals.Add(new ChecklistGoal("Attend the temple", "Go 10 times", 50, 10, 500));

        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nCurrent Score: {score}");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Show Goals");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
                    }
                    break;

                case "2":
                    Console.WriteLine("Select a goal to record:");
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
                    }
                    Console.Write("Enter number: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    score += goals[index].RecordEvent();
                    Console.WriteLine("Event recorded!");
                    break;

                case "3":
                    running = false;
                    break;
            }
        }
    }
}