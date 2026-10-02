using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Problem2_Dictionary
{
    static Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("STUDENT LOOKUP USING DICTIONARY");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    SearchStudent();
                    break;
                case "3":
                    DisplayAllStudents();
                    break;
                case "4":
                    Console.WriteLine("Program exited.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.\n");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter Student Number: ");
        string studentNumber = Console.ReadLine();

        if (studentDictionary.ContainsKey(studentNumber))
        {
            Console.WriteLine("Student Number already exists!\n");
            return;
        }

        Student s;
        s.StudentNumber = studentNumber;
        Console.Write("Enter Name: ");
        s.Name = Console.ReadLine();
        Console.Write("Enter Program: ");
        s.Program = Console.ReadLine();
        Console.Write("Enter Year Level: ");
        int.TryParse(Console.ReadLine(), out s.YearLevel);

        studentDictionary.Add(s.StudentNumber, s);
        Console.WriteLine("Student added successfully!\n");
    }

    static void SearchStudent()
    {
        Console.Write("Enter Student Number to search: ");
        string searchNumber = Console.ReadLine();

        if (studentDictionary.TryGetValue(searchNumber, out Student s))
        {
            Console.WriteLine("\nStudent Found!");
            Console.WriteLine($"Student Number: {s.StudentNumber}");
            Console.WriteLine($"Name: {s.Name}");
            Console.WriteLine($"Program: {s.Program}");
            Console.WriteLine($"Year Level: {s.YearLevel}\n");
        }
        else
        {
            Console.WriteLine("Student not found.\n");
        }
    }

    static void DisplayAllStudents()
    {
        if (studentDictionary.Count == 0)
        {
            Console.WriteLine("No student records found.\n");
            return;
        }

        Console.WriteLine("STUDENT RECORDS");
        Console.WriteLine("========================================");
        foreach (var s in studentDictionary.Values)
        {
            Console.WriteLine($"Student Number: {s.StudentNumber}");
            Console.WriteLine($"Name: {s.Name}");
            Console.WriteLine($"Program: {s.Program}");
            Console.WriteLine($"Year Level: {s.YearLevel}");
            Console.WriteLine("----------------------------------------");
        }
        Console.WriteLine();
    }
}
