using System;

namespace C_Sharp_Assign_2___LAB_2___Q1___ListGeneric
{
    internal class Program
    {
        static List<Contact> contactList = new List<Contact>();

        static void Main(string[] args)
        {
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("\nContact List Management System");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Display Contact");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Show All Contacts");
                Console.WriteLine("5. Quit");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        DisplayContact();
                        break;
                    case "3":
                        EditContact();
                        break;
                    case "4":
                        ShowAllContacts();
                        break;
                    case "5":
                        quit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                        break;
                }
            }
        }

        // Method to add a new contact to the list
        static void AddContact()
        {
            Console.WriteLine("Enter Contact Details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();

            Contact newContact = new Contact(name, phone, email, address);
            contactList.Add(newContact);

            Console.WriteLine("\nContact added successfully!");
        }

        // Method to display a particular contact from the list
        static void DisplayContact()
        {
            Console.Write("Enter Name of the Contact to Display: ");
            string name = Console.ReadLine();

            Contact foundContact = contactList.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (foundContact != null)
            {
                Console.WriteLine("\nContact Details:");
                Console.WriteLine(foundContact);
            }
            else
            {
                Console.WriteLine($"Contact with Name '{name}' not found.");
            }
        }

        // Method to edit details of a particular contact
        static void EditContact()
        {
            Console.Write("Enter Name of the Contact to Edit: ");
            string name = Console.ReadLine();

            Contact foundContact = contactList.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (foundContact != null)
            {
                Console.WriteLine("Enter New Contact Details:");
                Console.Write("Phone: ");
                foundContact.Phone = Console.ReadLine();
                Console.Write("Email: ");
                foundContact.Email = Console.ReadLine();
                Console.Write("Address: ");
                foundContact.Address = Console.ReadLine();

                Console.WriteLine("\nContact details updated successfully!");
            }
            else
            {
                Console.WriteLine($"Contact with Name '{name}' not found.");
            }
        }

        // Method to show all contacts in the list
        static void ShowAllContacts()
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("No contacts to display.");
            }
            else
            {
                Console.WriteLine("List of All Contacts:");
                foreach (var contact in contactList)
                {
                    Console.WriteLine(contact);
                }
            }
        }
    }

}