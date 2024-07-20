using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assign_2___Lab_6___Q1___Serialize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();

            // Accept data for multiple contacts
            Console.WriteLine("Enter details for multiple contacts (enter 'done' to finish):");
            while (true)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (name.ToLower() == "done")
                    break;

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Phone: ");
                string phone = Console.ReadLine();

                contacts.Add(new Contact(name, email, phone));
            }

            // Serialize the list of contacts to binary file
            SerializeContacts(contacts);

            Console.WriteLine("Contacts serialized to binary file.");

            Console.ReadLine(); // To keep console open after execution
        }

        static void SerializeContacts(List<Contact> contacts)
        {
            try
            {
                // Binary formatter
                BinaryFormatter formatter = new BinaryFormatter();

                // File to store serialized data
                using (FileStream fs = new FileStream("contacts.dat", FileMode.Create))
                {
                    formatter.Serialize(fs, contacts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during serialization: {ex.Message}");
            }
        }
    }
}
