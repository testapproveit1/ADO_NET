using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClass_Main
{
    public class Employee
    {
        public int EmployeeNumber { get; set; }
        public string Name { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal PF { get; set; }

        public Employee()
        {
            // Default constructor
        }

        public Employee(int employeeNumber, string name, decimal basicSalary, decimal pf)
        {
            EmployeeNumber = employeeNumber;
            Name = name;
            BasicSalary = basicSalary;
            PF = pf;
        }

        public decimal CalculateNetSalary()
        {
            // Example method to calculate net salary after deductions
            return BasicSalary - PF;
        }

        public override string ToString()
        {
            return $"Employee Number: {EmployeeNumber}, Name: {Name}, Basic Salary: {BasicSalary:C}, PF: {PF:C}";
        }

        // Static methods for managing employees
        private static List<Employee> employees = new List<Employee>();

        public static void AddEmployee(int empNo, string name, decimal basicSalary, decimal pf)
        {
            Employee newEmployee = new Employee(empNo, name, basicSalary, pf);
            employees.Add(newEmployee);
        }

        public static Employee SearchEmployee(int empNo)
        {
            return employees.Find(e => e.EmployeeNumber == empNo);
        }

        public static void DeleteEmployee(int empNo)
        {
            Employee employeeToRemove = employees.Find(e => e.EmployeeNumber == empNo);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
            }
        }

        public static List<Employee> GetAllEmployees()
        {
            return employees;
        }
    }
}
