using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assign_2___Lab_5___StreamReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the file path to read: ");
                string filePath = Console.ReadLine();

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File '{filePath}' does not exist.");
                    return;
                }

                // Read and display the contents of the file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
