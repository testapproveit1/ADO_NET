using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeClass_Main;


namespace EmployeeMgmtApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. Search Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. View All Employees");
                Console.WriteLine("5. Quit");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice.ToLower())
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        SearchEmployee();
                        break;
                    case "3":
                        DeleteEmployee();
                        break;
                    case "4":
                        ViewAllEmployees();
                        break;
                    case "5":
                        quit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                        break;
                }
            }
        }

        static void AddEmployee()
        {
            Console.WriteLine("Enter Employee Details:");
            Console.Write("Employee Number: ");
            int empNo = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Basic Salary: ");
            decimal basicSalary = decimal.Parse(Console.ReadLine());
            Console.Write("PF: ");
            decimal pf = decimal.Parse(Console.ReadLine());

            Employee.AddEmployee(empNo, name, basicSalary, pf);
            Console.WriteLine("\nEmployee added successfully!");
        }

        static void SearchEmployee()
        {
            Console.Write("Enter Employee Number to Search: ");
            int empNoToSearch = int.Parse(Console.ReadLine());

            Employee foundEmployee = Employee.SearchEmployee(empNoToSearch);

            if (foundEmployee != null)
            {
                Console.WriteLine("\nEmployee Found:");
                Console.WriteLine(foundEmployee);
            }
            else
            {
                Console.WriteLine($"Employee with Employee Number '{empNoToSearch}' not found.");
            }
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee Number to Delete: ");
            int empNoToDelete = int.Parse(Console.ReadLine());
            Employee.DeleteEmployee(empNoToDelete);
            Console.WriteLine("Employee deleted successfully!");
        }

        static void ViewAllEmployees()
        {
            List<Employee> employees = Employee.GetAllEmployees();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to display.");
            }
            else
            {
                Console.WriteLine("List of All Employees:");
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
    }
}
