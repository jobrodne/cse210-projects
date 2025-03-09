using System;

class Program
{
    static void Main(string[] args)
    {
        // Determine the letter grade based on the percentage
        Console.Write("Please enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        string letter;
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        // Print the letter grade
        Console.Write($"Your letter grade is {letter} ");
    
    // Check if the student passed or failed
    if (grade >= 70)
    {
        Console.Write("Congratulations, you passed the class!");
    }
    else 
    {
        Console.Write("Keep trying, you can do better next time!");
}
}
}