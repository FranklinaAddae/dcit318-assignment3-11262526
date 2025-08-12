using System;
using System.IO;
using Assignment3.Question1_Finance;
using Assignment3.Question2_Healthcare;
using Assignment3.Question3_Warehouse;
using Assignment3.Question4_Grading;

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
                Console.WriteLine("2. Question 2 - Healthcare System");
                Console.WriteLine("3. Question 3 - Warehouse Inventory Management");
                Console.WriteLine("4. Question 4 - Student Grading System");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect an option (1-5): ");

                string choice = Console.ReadLine()?.Trim();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        RunQuestion1();
                        Pause();
                        break;
                    case "2":
                        Console.Clear();
                        RunQuestion2();
                        Pause();
                        break;
                    case "3":
                        Console.Clear();
                        RunQuestion3();
                        Pause();
                        break;
                    case "4":
                        Console.Clear();
                        RunQuestion4();
                        Pause();
                        break;
                    case "5":
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

        static void RunQuestion2()
        {
            Console.WriteLine("=== Running Question 2: Healthcare System ===\n");
            var healthcareApp = new HealthcareApp();
            healthcareApp.Run();
        }

        static void RunQuestion3()
        {
            Console.WriteLine("=== Running Question 3: Warehouse Inventory Management ===\n");
            var manager = new Assignment3.Question3_Warehouse.WareHouseManager();
            manager.Run();
        }

        static void RunQuestion4()
        {
            Console.WriteLine("=== Question 4: Student Grading System ===\n");

            var processor = new Assignment3.Question4_Grading.StudentResultProcessor();

            // Always look for the file in the project root
            string projectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            string inputPath = Path.Combine(projectDir, "students.txt");
            string outputPath = Path.Combine(projectDir, "report.txt");

            try
            {
                var students = processor.ReadStudentsFromFile(inputPath);
                processor.WriteReportToFile(students, outputPath);

                Console.WriteLine("Report generated successfully!");
                Console.WriteLine($"Output file: {outputPath}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: Input file not found.");
            }
            catch (Assignment3.Question4_Grading.InvalidScoreFormatException ex)
            {
                Console.WriteLine($"Invalid Score: {ex.Message}");
            }
            catch (Assignment3.Question4_Grading.MissingFieldException ex)
            {
                Console.WriteLine($"Missing Field: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(intercept: true);
        }
    }
}
