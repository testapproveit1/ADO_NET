namespace Asmt2Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Accepting customer details from user input
                Console.WriteLine("Enter Customer ID:");
                int customerId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Customer Name:");
                string customerName = Console.ReadLine();

                Console.WriteLine("Enter Address:");
                string address = Console.ReadLine();

                Console.WriteLine("Enter City:");
                string city = Console.ReadLine();

                Console.WriteLine("Enter Phone:");
                string phone = Console.ReadLine();

                Console.WriteLine("Enter Credit Limit:");
                decimal creditLimit =Convert.ToDecimal(Console.ReadLine());

                Customer customer = new Customer(customerId, customerName, address, city, phone, creditLimit);
                Console.WriteLine("Customer created successfully.");
            }
            catch (InvalidCreditLimitException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        
    }
    }
}
