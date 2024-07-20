using System;
using C_Sharp_HOL_Part_1___LAB_1___Tasks;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of participants:");
        int participantCount = int.Parse(Console.ReadLine());

        Participant[] participants = new Participant[participantCount];

        for (int i = 0; i < participantCount; i++)
        {
            Console.WriteLine($"\nEnter details for participant {i + 1}:");

            Console.Write("EmpId: ");
            int empId = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Foundation Marks: ");
            int foundationMarks = int.Parse(Console.ReadLine());

            Console.Write("Web Basic Marks: ");
            int webBasicMarks = int.Parse(Console.ReadLine());

            Console.Write("DotNet Marks: ");
            int dotNetMarks = int.Parse(Console.ReadLine());

            participants[i] = new Participant(empId, name, foundationMarks, webBasicMarks, dotNetMarks);
        }

        foreach (var participant in participants)
        {
            Console.WriteLine($"\nParticipant {participant.EmpId} - {participant.Name}");
            Console.WriteLine($"Total Marks: {participant.ObtainedMarks}");
            Console.WriteLine($"Percentage: {participant.Percentage}%");
        }

        Console.ReadLine();
    }
}