namespace ADO.NET
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("------Employee Management System------");
            char choice;

            try
            {
                do
                {
                    Console.WriteLine("\nProduct Management System:");
                    Console.WriteLine("1. Add Category");
                    Console.WriteLine("2. Add Products");
                    Console.WriteLine("3. Update Products");
                    Console.WriteLine("4. Update Category");
                    Console.WriteLine("5. Delete Product");
                    Console.WriteLine("6. Search Product by Id");
                    Console.WriteLine("7. View Categories");
                    Console.WriteLine("8. View Products");
                    Console.WriteLine("9. Exit");
                    Console.Write("Choose an option: "); int op;
                    op = Convert.ToInt32(Console.ReadLine());
                    Product objProd = new Product();
                    switch (op)
                    {
                        case 1:
                            objProd.AddCategory();
                            break;
                        case 2:
                            objProd.AddProduct();
                            break;
                        case 3:
                            objProd.UpdateProduct();
                            break;
                        case 4:
                            objProd.UpdateCategory();
                            break;
                        case 5:
                            objProd.DeleteProduct();
                            break;
                        case 6:
                            objProd.SearchProduct();
                            break;
                        case 7:
                            objProd.ViewCategories();
                            break;
                        case 8:
                            objProd.ViewProducts();
                            break;
                        case 9:
                            break;
                    }
                    Console.WriteLine("Do you wish to continue enter y to continue");
                    choice = Convert.ToChar(Console.ReadLine());


                } while (choice == 'y');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
