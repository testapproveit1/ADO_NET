using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{

    internal class Product
    {
        private string connectionString = "Server=HYD-DS3FSX3\\SQLEXPRESS; Database=GEP; Integrated Security = True; Trusted_Connection=True; TrustServerCertificate=True";
        internal void AddCategory()
        {
            Console.Write("Enter Category Id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Category Name: ");
            var name = Console.ReadLine();

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Category (Id, Name) VALUES (@Id, @Name)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);

                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Category added successfully.");
                }
            }
        }

        internal void AddProduct()
        {
            Console.Write("Enter Product Id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            var price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Quantity In Hand: ");
            var quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Category Id: ");
            var categoryId = Convert.ToInt32(Console.ReadLine());

            if (!CategoryExists(categoryId))
            {
                Console.WriteLine("Error: Category does not exist.");
                return;
            }

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Product (Id, Name, Price, QuantityInHand, CategoryId) VALUES (@Id, @Name, @Price, @QuantityInHand, @CategoryId)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@QuantityInHand", quantity);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Product added successfully.");
                }
            }
        }

        internal void ViewProducts()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT p.Id, p.Name, p.Price, p.QuantityInHand, c.Name as CategoryName FROM Product p JOIN Category c ON p.CategoryId = c.Id";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Id\tName\t\tPrice\tQuantity\tCategory");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Id"]}\t{reader["Name"]}\t\t{reader["Price"]}\t{reader["QuantityInHand"]}\t{reader["CategoryName"]}");
                        }
                    }
                }
            }
        }
        internal bool CategoryExists(int categoryId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT COUNT(*) FROM Category WHERE Id = @CategoryId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        internal void UpdateCategory()
        {
            Console.Write("Enter Category Id to update: ");
            var id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Category Name: ");
            var name = Console.ReadLine();

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "UPDATE Category SET Name = @Name WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Category updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Category not found.");
                    }
                }
            }
        }
        internal void UpdateProduct()
        {
            Console.Write("Enter Product Id to update: ");
            var id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Product Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter New Product Price: ");
            var price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter New Quantity In Hand: ");
            var quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Category Id: ");
            var categoryId = Convert.ToInt32(Console.ReadLine());

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "UPDATE Product SET Name = @Name, Price = @Price, QuantityInHand = @QuantityInHand, CategoryId = @CategoryId WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@QuantityInHand", quantity);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Product updated successfully.");
                }
            }
        }


        internal void DeleteProduct()
        {
            Console.Write("Enter Product Id to delete: ");
            var id = Convert.ToInt32(Console.ReadLine());

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "DELETE FROM Product WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Product deleted successfully.");
                }
            }
        }
        internal void ViewCategories()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT Id, Name FROM Category";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Id\tName");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Id"]}\t{reader["Name"]}");
                        }
                    }
                }
            }
        }
        internal void SearchProduct()
        {
            Console.Write("Enter Product Id to search: ");
            var id = Convert.ToInt32(Console.ReadLine());

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT p.Id, p.Name, p.Price, p.QuantityInHand, c.Name as CategoryName " +
                            "FROM Product p JOIN Category c ON p.CategoryId = c.Id " +
                            "WHERE p.Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("Id\tName\t\tPrice\tQuantity\tCategory");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Id"]}\t{reader["Name"]}\t\t{reader["Price"]}\t{reader["QuantityInHand"]}\t{reader["CategoryName"]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No products found with the given Id.");
                        }
                    }
                }
            }
        }

    }
}
