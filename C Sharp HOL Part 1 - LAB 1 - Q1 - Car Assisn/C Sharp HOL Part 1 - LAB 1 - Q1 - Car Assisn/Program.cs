using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace C_Sharp_HOL_Part_1___LAB_1___Q1___Car_Assisn
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal SalePrice { get; set; }

        public Car(string make, string model, int year, decimal salePrice)
        {
            Make = make;
            Model = model;
            Year = year;
            SalePrice = salePrice;
        }
    }

    public class Program
    {
        private static Car[] inventory = new Car[100]; // Array to store cars (assuming max 100 cars)
        private static int count = 0; // Count of cars in inventory

        public static void Main()
        {
            bool quit = false;

            Console.WriteLine("Welcome to Used Car Inventory Management System");

            while (!quit)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Add a new car");
                Console.WriteLine("2. Modify details of a car");
                Console.WriteLine("3. Search for a car");
                Console.WriteLine("4. List all cars");
                Console.WriteLine("5. Delete a car");
                Console.WriteLine("6. Quit");

                Console.Write("\nEnter your choice (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        ModifyCar();
                        break;
                    case "3":
                        SearchCar();
                        break;
                    case "4":
                        ListCars();
                        break;
                    case "5":
                        DeleteCar();
                        break;
                    case "6":
                        quit = true;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Unknown command. Please enter a valid option (1-6).");
                        break;
                }
            }
        }

        // Method to add a new car to the inventory
        private static void AddCar()
        {
            Console.WriteLine("\nEnter car details:");
            Console.Write("Make: ");
            string make = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Sale Price: ");
            decimal salePrice = decimal.Parse(Console.ReadLine());

            Car newCar = new Car(make, model, year, salePrice);
            inventory[count] = newCar;
            count++;

            Console.WriteLine("Car added successfully!");
        }

        // Method to modify details of a car in the inventory
        private static void ModifyCar()
        {
            Console.Write("\nEnter the make of the car to modify: ");
            string makeToModify = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (inventory[i].Make.Equals(makeToModify, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter new details:");
                    Console.Write("Make: ");
                    inventory[i].Make = Console.ReadLine();
                    Console.Write("Model: ");
                    inventory[i].Model = Console.ReadLine();
                    Console.Write("Year: ");
                    inventory[i].Year = int.Parse(Console.ReadLine());
                    Console.Write("Sale Price: ");
                    inventory[i].SalePrice = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Car details modified successfully!");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Car with make '{makeToModify}' not found.");
            }
        }

        // Method to search for a car in the inventory
        private static void SearchCar()
        {
            Console.Write("\nEnter the make of the car to search: ");
            string makeToSearch = Console.ReadLine();

            bool found = false;

            foreach (Car car in inventory)
            {
                if (car != null && car.Make.Equals(makeToSearch, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Car found:\nMake: {car.Make}, Model: {car.Model}, Year: {car.Year}, Sale Price: {car.SalePrice:C}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Car with make '{makeToSearch}' not found.");
            }
        }

        // Method to list all cars in the inventory
        private static void ListCars()
        {
            if (count == 0)
            {
                Console.WriteLine("No cars in inventory.");
            }
            else
            {
                Console.WriteLine("List of Cars in Inventory:");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"Car {i + 1}: {inventory[i].Make}, {inventory[i].Model}, {inventory[i].Year}, Sale Price: {inventory[i].SalePrice:C}");
                }
            }
        }

        // Method to delete a car from the inventory
        private static void DeleteCar()
        {
            Console.Write("\nEnter the make of the car to delete: ");
            string makeToDelete = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (inventory[i].Make.Equals(makeToDelete, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        inventory[j] = inventory[j + 1];
                    }
                    count--;
                    Console.WriteLine("Car deleted successfully!");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Car with make '{makeToDelete}' not found.");
            }
        }
    }
}