using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_HOL_Part_1___LAB_2__Q1___Polymorphism
{
    internal class PermanentEmployee : Employee
    {
        public int NoOfLeaves { get; set; }
        public double ProvidendFund { get; set; }
        public PermanentEmployee(string empId, string name, string companyName, double salary, int noOfLeaves, double providendFund)
        {
            EmpId = empId;
            Name = name;
            CompanyName = companyName;
            Salary = salary;
            NoOfLeaves = noOfLeaves;
            ProvidendFund = providendFund;
        }
        public override double GetSalary()
        {
            return Salary - ProvidendFund;
        }
    }
}
