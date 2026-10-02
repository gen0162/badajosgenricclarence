using System;
using System.Collections.Generic;

struct Operation
{
    public string Action;
    public string StudentNumber;
    public string StudentName;
}

class Problem4_Stack
{
    static Stack<Operation> operationHistory = new Stack<Operation>();

    static void Main()
    {
        RecordOperation("Added", "Genricpogi");
        RecordOperation("Added", "Kylie");
        RecordOperation("Updated", "Genricpogi");
        RecordOperation("Deleted", "Kylie");

        while (true)
        {
            Console.WriteLine("OPERATION HISTORY");
            Console.WriteLine("1. View Operation History");
            Console.WriteLine("2. View Last Operation");
            Console.WriteLine("3. Remove Last Operation");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ViewOperationHistory();
                    break;
                case "2":
                    ViewLastOperation();
                    break;
                case "3":
                    RemoveLastOperation();
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

    static void RecordOperation(string action, string studentName, string studentNumber = "")
    {
        Operation op;
        op.Action = action;
        op.StudentName = studentName;
        op.StudentNumber = studentNumber;
        operationHistory.Push(op);
    }

    static void ViewOperationHistory()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No operations recorded.\n");
            return;
        }

        Console.WriteLine("OPERATION HISTORY");
        Operation[] ops = operationHistory.ToArray();
        Array.Reverse(ops);

        for (int i = 0; i < ops.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {ops[i].Action} {ops[i].StudentName}");
        }
        Console.WriteLine();
    }

    static void ViewLastOperation()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No operations recorded.\n");
            return;
        }

        Operation lastOp = operationHistory.Peek();
        Console.WriteLine($"Last Operation: {lastOp.Action} {lastOp.StudentName}\n");
    }

    static void RemoveLastOperation()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No operations recorded.\n");
            return;
        }

        operationHistory.Pop();
        Console.WriteLine("Last operation removed successfully!\n");
    }
}
