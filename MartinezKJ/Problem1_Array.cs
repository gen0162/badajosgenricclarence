using System;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Problem1_Array
{
    static Student[] students = new Student[10];
    static int studentCount = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("STUDENT RECORD MANAGEMENT");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    DisplayAllStudents();
                    break;
                case "3":
                    SearchStudent();
                    break;
                case "4":
                    UpdateStudent();
                    break;
                case "5":
                    DeleteStudent();
                    break;
                case "6":
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
        if (studentCount >= 10)
        {
            Console.WriteLine("Cannot add more students. Maximum limit reached.\n");
            return;
        }

        Student s;
        Console.Write("Enter Student Number: ");
        s.StudentNumber = Console.ReadLine();
        Console.Write("Enter Name: ");
        s.Name = Console.ReadLine();
        Console.Write("Enter Program: ");
        s.Program = Console.ReadLine();
        Console.Write("Enter Year Level: ");
        int.TryParse(Console.ReadLine(), out s.YearLevel);

        students[studentCount] = s;
        studentCount++;

        Console.WriteLine("Student added successfully!\n");
    }

    static void DisplayAllStudents()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("No student records found.\n");
            return;
        }

        Console.WriteLine("STUDENT RECORDS");
        Console.WriteLine("========================================");
        for (int i = 0; i < studentCount; i++)
        {
            Console.WriteLine($"Student Number: {students[i].StudentNumber}");
            Console.WriteLine($"Name: {students[i].Name}");
            Console.WriteLine($"Program: {students[i].Program}");
            Console.WriteLine($"Year Level: {students[i].YearLevel}");
            if (i < studentCount - 1)
            {
                Console.WriteLine("----------------------------------------");
            }
        }
        Console.WriteLine();
    }

    static void SearchStudent()
    {
        Console.Write("Enter Student Number to search: ");
        string searchNumber = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].StudentNumber == searchNumber)
            {
                Console.WriteLine("\nStudent Found!");
                Console.WriteLine($"Student Number: {students[i].StudentNumber}");
                Console.WriteLine($"Name: {students[i].Name}");
                Console.WriteLine($"Program: {students[i].Program}");
                Console.WriteLine($"Year Level: {students[i].YearLevel}\n");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Student not found.\n");
        }
    }

    static void UpdateStudent()
    {
        Console.Write("Enter Student Number to update: ");
        string updateNumber = Console.ReadLine();
        int index = -1;

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].StudentNumber == updateNumber)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Student not found.\n");
            return;
        }

        Console.Write("Enter New Name: ");
        students[index].Name = Console.ReadLine();
        Console.Write("Enter New Program: ");
        students[index].Program = Console.ReadLine();
        Console.Write("Enter New Year Level: ");
        int.TryParse(Console.ReadLine(), out students[index].YearLevel);

        Console.WriteLine("Student updated successfully!\n");
    }

    static void DeleteStudent()
    {
        Console.Write("Enter Student Number to delete: ");
        string deleteNumber = Console.ReadLine();
        int index = -1;

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].StudentNumber == deleteNumber)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Student not found.\n");
            return;
        }

        for (int j = index; j < studentCount - 1; j++)
        {
            students[j] = students[j + 1];
        }
        studentCount--;

        Console.WriteLine("Student deleted successfully!\n");
    }
}
