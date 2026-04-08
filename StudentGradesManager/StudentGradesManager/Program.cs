using System;

class Program
{
    static void Main()
    {
        RunMenu();
    }

    static void RunMenu()
    {
        string[] names = new string[100];
        int[] grades = new int[100];
        int count = 0;

        int choice;

        while (true)
        {
            Console.WriteLine("\n--- Student Manager ---");
            Console.WriteLine("1 - Add Student");
            Console.WriteLine("2 - Show Students");
            Console.WriteLine("3 - Show Average");
            Console.WriteLine("4 - Top Student");
            Console.WriteLine("5 - Exit");

            Console.Write("Choose option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    count = AddStudents(names, grades, count);
                    break;

                case 2:
                    PrintStudents(names, grades, count);
                    break;

                case 3:
                    ShowAverage( grades, count);
                    break;

                case 4:
                    GetMaxStudent(names, grades, count);
                    break;

                case 5:
                    Console.WriteLine("Program ended.");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static int AddStudents(string[] names, int[] grades, int count)
    {
        string again = "y";

        while (again == "y")
        {
            Console.Write("Enter student name: ");
            names[count] = Console.ReadLine();

            Console.Write("Enter grade: ");
            grades[count] = int.Parse(Console.ReadLine());

            count++;

            Console.Write("Add another student? (y/n): ");
            again = Console.ReadLine().ToLower();
        }

        return count;
    }

    static void PrintStudents(string[] names, int[] grades, int count)
    {
        Console.WriteLine("\nStudents List:");

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{names[i]} : {grades[i]}");
        }
    }

    static double ShowAverage( int[] grades, int count)
    {
        int sum = 0;

        for (int i = 0; i < count; i++)
        {
            sum += grades[i];
        }

        return (double)sum / count;
    }

    static void GetMaxStudent(string[] names, int[] grades, int count)
    {
        int max = grades[0];
        int index = 0;

        for (int i = 1; i < count; i++)
        {
            if (grades[i] > max)
            {
                max = grades[i];
                index = i;
            }
        }

        Console.WriteLine($"\nTop Student: {names[index]} - Grade: {max}");
    }
}