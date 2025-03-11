using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nChoose a program to run:");
            Console.WriteLine("1. Name Formatter");
            Console.WriteLine("2. Grade Calculator");
            Console.WriteLine("3. Guess My Number");
            Console.WriteLine("4. List Operations");
            Console.WriteLine("5. Number Squaring");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    NameFormatter();
                    break;
                case "2":
                    GradeCalculator();
                    break;
                case "3":
                    GuessMyNumber();
                    break;
                case "4":
                    ListOperations();
                    break;
                case "5":
                    NumberSquaring();
                    break;
                case "0":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void NameFormatter()
    {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }

    static void GradeCalculator()
    {
        Console.Write("Enter your grade percentage: ");
        if (!int.TryParse(Console.ReadLine(), out int gradePercentage))
        {
            Console.WriteLine("Invalid input. Please enter a numeric grade percentage.");
            return;
        }

        string letter = "";
        string sign = "";

        if (gradePercentage >= 90) letter = "A";
        else if (gradePercentage >= 80) letter = "B";
        else if (gradePercentage >= 70) letter = "C";
        else if (gradePercentage >= 60) letter = "D";
        else letter = "F";

        int lastDigit = gradePercentage % 10;

        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7) sign = "+";
            else if (lastDigit < 3) sign = "-";
        }
        else if (letter == "A" && gradePercentage < 94)
        {
            sign = "-";
        }

        Console.WriteLine($"\nYour grade is: {letter}{sign}");
        Console.WriteLine(gradePercentage >= 70 ? "Congratulations! You passed the course. 🎉" : "Keep working hard! You'll do better next time. 💪");
    }

    static void GuessMyNumber()
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            int guess = -1, guessCount = 0;

            Console.WriteLine("\nWelcome to the Guess My Number game!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                if (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber) Console.WriteLine("Higher");
                else if (guess > magicNumber) Console.WriteLine("Lower");
                else Console.WriteLine($"You guessed it! 🎉 It took you {guessCount} tries.");
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().Trim().ToLower() == "yes";
        }

        Console.WriteLine("Thanks for playing! Goodbye. 👋");
    }

    static void ListOperations()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("\nEnter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }
            if (number == 0) break;
            numbers.Add(number);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered. Exiting program.");
            return;
        }

        int sum = numbers.Sum();
        double average = numbers.Average();
        int maxNumber = numbers.Max();
        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        int smallestPositive = positiveNumbers.Count > 0 ? positiveNumbers.Min() : 0;

        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");
        if (positiveNumbers.Count > 0) Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        numbers.ForEach(num => Console.WriteLine(num));
    }

    static void NumberSquaring()
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome() => Console.WriteLine("\nWelcome to the program!");
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        while (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.Write("Invalid input. Please enter a valid integer: ");
        }
        return number;
    }
    static int SquareNumber(int number) => number * number;
    static void DisplayResult(string name, int squaredNumber) => Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
}