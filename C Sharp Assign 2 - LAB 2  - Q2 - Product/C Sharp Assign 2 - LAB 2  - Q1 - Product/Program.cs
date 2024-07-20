using System;
using System.Collections;
using System.Collections.Generic;


namespace C_Sharp_Assign_2___LAB_2____Q1___Product
{
    public class Product
    {
        public int ProductNo { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public int Stock { get; set; }

        public Product(int productNo, string name, decimal rate, int stock)
        {
            ProductNo = productNo;
            Name = name;
            Rate = rate;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"Product No: {ProductNo}, Name: {Name}, Rate: {Rate:C}, Stock: {Stock}";
        }
    }

    class Program
    {
        static ArrayList productList = new ArrayList();

        static void Main(string[] args)
        {
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("\nProduct Management System");
                Console.WriteLine("a. Adding New Product");
                Console.WriteLine("b. Deleting Currently Searched Product");
                Console.WriteLine("c. Searching Product");
                Console.WriteLine("d. Save the New Product (Sorted by ProductNo)");
                Console.WriteLine("e. Quit");
                Console.Write("Enter your choice (a-e): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice.ToLower())
                {
                    case "a":
                        AddProduct();
                        break;
                    case "b":
                        DeleteProduct();
                        break;
                    case "c":
                        SearchProduct();
                        break;
                    case "d":
                        SaveProductsSortedByProductNo();
                        break;
                    case "e":
                        quit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (a-e).");
                        break;
                }
            }
        }

        // Method to add a new product to the ArrayList
        static void AddProduct()
        {
            Console.WriteLine("Enter Product Details:");
            Console.Write("Product No: ");
            int productNo = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Rate: ");
            decimal rate = decimal.Parse(Console.ReadLine());
            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            Product newProduct = new Product(productNo, name, rate, stock);
            productList.Add(newProduct);

            Console.WriteLine("\nProduct added successfully!");
        }

        // Method to delete a product by its ProductNo
        static void DeleteProduct()
        {
            Console.Write("Enter ProductNo of the Product to Delete: ");
            int productNoToDelete = int.Parse(Console.ReadLine());

            Product productToRemove = null;

            foreach (var item in productList)
            {
                if (item is Product product && product.ProductNo == productNoToDelete)
                {
                    productToRemove = product;
                    break;
                }
            }
            if (productToRemove != null)
            {
                productList.Remove(productToRemove);
                Console.WriteLine("Product deleted successfully!");
            }
            else
            {
                Console.WriteLine($"Product with ProductNo '{productNoToDelete}' not found.");
            }
        }

        // Method to search for a product by its ProductNo
        static void SearchProduct()
        {
            Console.Write("Enter ProductNo to Search: ");
            int productNoToSearch = int.Parse(Console.ReadLine());

            Product foundProduct = null;

            foreach (var item in productList)
            {
                if (item is Product product && product.ProductNo == productNoToSearch)
                {
                    foundProduct = product;
                    break;
                }
            }
            if (foundProduct != null)
            {
                Console.WriteLine("\nProduct Found:");
                Console.WriteLine(foundProduct);
            }
            else
            {
                Console.WriteLine($"Product with ProductNo '{productNoToSearch}' not found.");
            }
        }

        // Method to save products sorted by ProductNo
        static void SaveProductsSortedByProductNo()
        {
            productList.Sort(new ProductNoComparer());
            Console.WriteLine("Products saved in sorted order by ProductNo.");
        }
    }

    // Comparer class to sort products by ProductNo
    public class ProductNoComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Product productX = x as Product;
            Product productY = y as Product;

            if (productX != null && productY != null)
            {
                return productX.ProductNo.CompareTo(productY.ProductNo);
            }
            else
            {
                throw new ArgumentException("Object is not of type Product.");
            }
        }
    }
}