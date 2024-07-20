using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_HOL_Part_1___LAB_2__Q1___Polymorphism
{
    internal class ContractEmployee : Employee
    {
        public double Perks { get; set; }
        public ContractEmployee(string empId, string name, string companyName, double salary, double perks)
        {
            EmpId = empId;
            Name = name;
            CompanyName = companyName;
            Salary = salary;
            Perks = perks;
        }
        public override double GetSalary()
        {
            return Salary + Perks;
        }
    }
}
