using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assign_2___Lab_3___Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new dictionary with string keys and string values
            Dictionary<string, string> fileExtensions = new Dictionary<string, string>();

            // Add elements to the dictionary
            fileExtensions.Add("txt", "Text File");
            fileExtensions.Add("jpg", "JPEG Image");
            fileExtensions.Add("pdf", "Portable Document Format");
            fileExtensions.Add("mp3", "MP3 Audio");

            // Print initial dictionary contents
            Console.WriteLine("Initial Dictionary Contents:");
            PrintDictionary(fileExtensions);

            // Test other functionalities as per the tasks
            TestDictionaryOperations(fileExtensions);
            Console.ReadLine();
        }

        static void PrintDictionary(Dictionary<string, string> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            Console.WriteLine();
        }

        static void TestDictionaryOperations(Dictionary<string, string> fileExtensions)
        {
            // Task 2: Attempt to add a duplicate key
            try
            {
                fileExtensions.Add("jpg", "JPEG File"); // This will throw an ArgumentException
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Task 3: Use the indexer to change the value associated with a key
            fileExtensions["jpg"] = "JPEG Image File";

            // Print dictionary after changing value
            Console.WriteLine("\nDictionary after updating 'jpg' key:");
            PrintDictionary(fileExtensions);

            // Task 4: Adding a new key/value pair using the indexer
            fileExtensions["doc"] = "Microsoft Word Document";

            // Print dictionary after adding new key
            Console.WriteLine("\nDictionary after adding 'doc' key:");
            PrintDictionary(fileExtensions);

            // Task 5: Handling exception when key is not found using indexer
            string keyToSearch = "html";
            try
            {
                string fileType = fileExtensions[keyToSearch];
                Console.WriteLine($"Value for '{keyToSearch}': {fileType}");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Key '{keyToSearch}' not found. Error: {ex.Message}");
            }

            // Task 6: Enumerating dictionary elements using foreach
            Console.WriteLine("\nEnumerating dictionary elements using foreach:");
            foreach (var kvp in fileExtensions)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            // Task 7: Removing a key/value pair
            string keyToRemove = "mp3";
            fileExtensions.Remove(keyToRemove);
            Console.WriteLine($"\nRemoved '{keyToRemove}' key from dictionary.");

            // Print final dictionary contents
            Console.WriteLine("\nFinal Dictionary Contents:");
            PrintDictionary(fileExtensions);
        }
    }
}
