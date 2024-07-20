using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assign_2___LAB_2___Q1___ListGeneric
{
    internal class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Contact(string name, string phone, string email, string address)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nPhone: {Phone}\nEmail: {Email}\nAddress: {Address}\n";
        }
    }
}
