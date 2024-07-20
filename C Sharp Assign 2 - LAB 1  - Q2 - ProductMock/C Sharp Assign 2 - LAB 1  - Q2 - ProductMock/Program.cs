using System;

namespace  C_Sharp_Assign_2___LAB_1____Q2___ProductMock
{
    class Program
    {
        class DataEntryException : Exception
        {
            public DataEntryException(string message)
                : base(message)
            {

            }
        }
        class ProductMock
        {
            private int productId;


            public int ProductId
            {
                get { return productId; }
                set
                {
                    //productID <=0 | Product ID must be greater than zero 
                    if (value <= 0)
                    {
                        throw new DataEntryException("Product ID must be greater than zero.");
                    }
                    productId = value;
                }
            }
            private string productName;


            public string ProductName
            {
                get { return productName; }
                set
                {
                    //productName = = "" | Product Name cannot be left blank
                    if (value == "")
                    {
                        throw new DataEntryException("Product Name cannot be left blank.");
                    }
                    //productName | Product Name should have alphabets and numbers only
                    bool isLetterorNumbers = true;
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!char.IsLetter(value[i]) && !char.IsDigit(value[i]))
                        {
                            isLetterorNumbers = false;
                            break;
                        }
                    }
                    if (!isLetterorNumbers)
                    {
                        throw new DataEntryException("Product Name should have alphabets and numbers only.");
                    }
                    productName = value;
                }
            }
            private double price;


            public double Price
            {
                get { return price; }
                set
                {
                    //price <=0 | Price of product must be greater than zero.
                    if (value <= 0)
                    {
                        throw new DataEntryException("Price of product must be greater than zero.");
                    }
                    price = value;
                }
            }




        }


        static void Main(string[] args)
        {


            try
            {
                int productId;
                string productName;
                double price;
                ProductMock productMock = new ProductMock();


                Console.Write("Enter Id: ");
                productId = int.Parse(Console.ReadLine());
                Console.Write("Enter Product Name: ");
                productName = Console.ReadLine();
                Console.Write("Enter Price: ");
                price = double.Parse(Console.ReadLine());


                productMock.ProductId = productId;
                productMock.ProductName = productName;
                productMock.Price = price;
            }
            catch (DataEntryException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }


            Console.ReadKey();


        }
    }
}
