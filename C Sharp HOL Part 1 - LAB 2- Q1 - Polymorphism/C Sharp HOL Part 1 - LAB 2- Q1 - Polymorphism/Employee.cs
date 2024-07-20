using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_HOL_Part_1___LAB_2__Q1___Polymorphism
{
    internal abstract class Employee
    {
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public double Salary { get; set; }

        public abstract double GetSalary();
    }

}
