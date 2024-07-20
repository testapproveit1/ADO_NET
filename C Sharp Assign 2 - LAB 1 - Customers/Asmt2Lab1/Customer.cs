using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmt2Lab1
{

    public class InvalidCreditLimitException : Exception
    {
        public InvalidCreditLimitException(decimal creditLimit)
            : base($"Credit limit of {creditLimit} exceeds the allowed maximum of 50000.")
        {
        }
    }
    public class Customer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Phone { get; set; }

            private decimal creditLimit;
            public decimal CreditLimit
            {
                get { return creditLimit; }
                set
                {
                    if (value > 50000)
                    {
                        throw new InvalidCreditLimitException(value);
                    }
                    creditLimit = value;
                }
            }
            public Customer()
            {
            }

            // Parameterized constructor
            public Customer(int customerId, string customerName, string address, string city, string phone, decimal creditLimit)
            {
                CustomerId = customerId;
                CustomerName = customerName;
                Address = address;
                City = city;
                Phone = phone;
                CreditLimit = creditLimit; 
            }
        }
    
}
