namespace C_Sharp_HOL_Part_1___LAB_2__Q1___Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose the type of employee:\n1. Contract Employee\n2. Permanent Employee\n3. Quit");
                string choice = Console.ReadLine();

                if (choice == "3")
                {
                    Console.WriteLine("Exiting the program");
                    Environment.Exit(0);
                }

                Console.Write("Enter Employee ID: ");
                string empId = Console.ReadLine();

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Company Name: ");
                string companyName = Console.ReadLine();

                Console.Write("Enter Salary: ");
                double salary = Convert.ToDouble(Console.ReadLine());

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Perks: ");
                        double perks = Convert.ToDouble(Console.ReadLine());
                        ContractEmployee contractEmployee = new ContractEmployee(empId, name, companyName, salary, perks);
                        Console.WriteLine("Salary of Contract Employee: {0}", contractEmployee.GetSalary());
                        break;

                    case "2":
                        Console.Write("Enter Number of Leaves: ");
                        int noOfLeaves = int.Parse(Console.ReadLine());
                        Console.Write("Enter Providend Fund: ");
                        double providendFund = Convert.ToDouble(Console.ReadLine());
                        PermanentEmployee permanentEmployee = new PermanentEmployee(empId, name, companyName, salary, noOfLeaves, providendFund);
                        Console.WriteLine("Salary of Permanent Employee: {0}", permanentEmployee.GetSalary());
                        break;

                    default:
                        Console.WriteLine("Unknown command. Please enter a valid choice.");
                        break;
                }
            }
        }
    }
    }