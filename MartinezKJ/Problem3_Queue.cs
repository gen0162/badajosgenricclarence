using System;
using System.Collections.Generic;

struct StudentRequest
{
    public string StudentNumber;
    public string StudentName;
    public string RequestType;
}

class Problem3_Queue
{
    static Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("STUDENT REQUEST QUEUE");
            Console.WriteLine("1. Add Request");
            Console.WriteLine("2. View Pending Requests");
            Console.WriteLine("3. Process Request");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddRequest();
                    break;
                case "2":
                    ViewPendingRequests();
                    break;
                case "3":
                    ProcessRequest();
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

    static void AddRequest()
    {
        StudentRequest req;
        Console.Write("Enter Student Number: ");
        req.StudentNumber = Console.ReadLine();
        Console.Write("Enter Student Name: ");
        req.StudentName = Console.ReadLine();
        Console.Write("Enter Request Type: ");
        req.RequestType = Console.ReadLine();

        requestQueue.Enqueue(req);
        Console.WriteLine("Request added successfully!\n");
    }

    static void ViewPendingRequests()
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("No pending requests.\n");
            return;
        }

        Console.WriteLine("REQUEST QUEUE");
        int count = 1;
        foreach (var req in requestQueue)
        {
            Console.WriteLine($"{count}. {req.StudentName} - {req.RequestType}");
            count++;
        }
        Console.WriteLine();
    }

    static void ProcessRequest()
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("No pending requests.\n");
            return;
        }

        StudentRequest req = requestQueue.Dequeue();
        Console.WriteLine($"Processing Request: {req.StudentName} - {req.RequestType}");
        Console.WriteLine("Request processed successfully!\n");
    }
}
