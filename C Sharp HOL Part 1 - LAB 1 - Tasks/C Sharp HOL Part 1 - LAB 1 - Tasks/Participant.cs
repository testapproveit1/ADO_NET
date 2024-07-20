using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_HOL_Part_1___LAB_1___Tasks
{
    public class Participant
    {
        // Private fields
        private int empId;
        private string name;
        private static string companyName;
        private int foundationMarks;
        private int webBasicMarks;
        private int dotNetMarks;
        private const int totalMarks = 300;

        // Public properties
        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public static string CompanyName
        {
            get { return companyName; }
        }

        public int FoundationMarks
        {
            get { return foundationMarks; }
            set { foundationMarks = ValidateMarks(value); }
        }

        public int WebBasicMarks
        {
            get { return webBasicMarks; }
            set { webBasicMarks = ValidateMarks(value); }
        }

        public int DotNetMarks
        {
            get { return dotNetMarks; }
            set { dotNetMarks = ValidateMarks(value); }
        }

        public int ObtainedMarks
        {
            get { return CalculateTotalMarks(); }
        }

        public double Percentage
        {
            get { return CalculatePercentage(); }
        }

        // Static constructor
        static Participant()
        {
            companyName = "Corporate University";
        }

        // Default constructor
        public Participant()
        {
            empId = 0;
            name = string.Empty;
            foundationMarks = 0;
            webBasicMarks = 0;
            dotNetMarks = 0;
        }

        // Parameterized constructor
        public Participant(int empId, string name, int foundationMarks, int webBasicMarks, int dotNetMarks)
        {
            this.empId = empId;
            this.name = name;
            this.foundationMarks = ValidateMarks(foundationMarks);
            this.webBasicMarks = ValidateMarks(webBasicMarks);
            this.dotNetMarks = ValidateMarks(dotNetMarks);
        }

        // Method to calculate total marks
        private int CalculateTotalMarks()
        {
            return foundationMarks + webBasicMarks + dotNetMarks;
        }

        // Method to calculate percentage
        private double CalculatePercentage()
        {
            return (double)ObtainedMarks / totalMarks * 100;
        }

        // Method to validate marks
        private int ValidateMarks(int marks)
        {
            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid marks entered. Assigning 0.");
                return 0;
            }
            return marks;
        }

        // Method to return the percentage
        public double GetPercentage()
        {
            return Percentage;
        }
    }
}
