using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assign_2___Lab_6___Q2___DeSerialize
{
    internal class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Contact(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Phone: {Phone}";
        }
    }
}
