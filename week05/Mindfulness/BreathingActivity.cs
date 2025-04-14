using System;

public class BreathingActivity : MindfulnessActivity
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