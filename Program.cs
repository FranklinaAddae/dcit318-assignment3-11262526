using System;
using Assignment3.Question1_Finance;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== DCIT 318 - Assignment 3 ===");
                Console.WriteLine("1. Question 1 - Finance Management System");
                Console.WriteLine("2. Exit");
                Console.Write("\nSelect an option (1-2): ");

                string choice = Console.ReadLine()?.Trim();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        RunQuestion1();
                        Pause();
                        break;
                    case "2":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Try again.");
                        Pause();
                        break;
                }
            }
        }

        static void RunQuestion1()
        {
            Console.WriteLine("=== Running Question 1: Finance Management System ===\n");
            var financeApp = new FinanceApp();
            financeApp.Run();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(intercept: true);
        }
    }
}
