using System;

namespace C_Sharp_HOL_Part_1___LAB_3
{
    // Enum definition
    public enum BankAccountTypeEnum
    {
        Current = 1,
        Savings = 2
    }

    // Abstract class implementation
    public abstract class BankAccount : IBankAccount
    {
        // Properties from IBankAccount
        public int AccountNumber { get; protected set; }
        public string AccountHolderName { get; set; }
        public abstract decimal Balance { get; protected set; } // Allow overriding with set accessor

        // Methods from IBankAccount
        public abstract double GetBalance();
        public abstract void Deposit(double amount);
        public abstract bool Withdraw(double amount);
        public abstract bool Transfer(IBankAccount toAccount, double amount);

        // Additional property
        public abstract BankAccountTypeEnum BalanceType { get; }
    }

    // Concrete class ICICI
    public class ICICI : BankAccount
    {
        // Fields specific to ICICI bank rules
        private const decimal MinimumWithdrawBalance = 0;
        private const decimal MinimumTransferBalance = 1000;

        // Properties
        public override decimal Balance { get; protected set; }
        public override BankAccountTypeEnum BalanceType => BankAccountTypeEnum.Savings;

        // Constructor
        public ICICI(int accountNumber, string accountHolderName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
        }

        // Methods
        public override double GetBalance()
        {
            return (double)Balance;
        }

        public override void Deposit(double amount)
        {
            Balance += (decimal)amount;
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
        }

        public override bool Withdraw(double amount)
        {
            if (Balance - (decimal)amount >= MinimumWithdrawBalance)
            {
                Balance -= (decimal)amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {Balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine($"Insufficient balance to withdraw {amount:C}. Current balance: {Balance:C}");
                return false;
            }
        }

        public override bool Transfer(IBankAccount toAccount, double amount)
        {
            if (Balance - (decimal)amount >= MinimumTransferBalance)
            {
                if (toAccount is BankAccount targetAccount)
                {
                    Balance -= (decimal)amount;
                    targetAccount.Deposit(amount);
                    Console.WriteLine($"Transferred {amount:C} to {targetAccount.AccountHolderName}. New balance: {Balance:C}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid target account for transfer.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Insufficient balance to transfer {amount:C}. Current balance: {Balance:C}");
                return false;
            }
        }
    }

    // Concrete class HSBC
    public class HSBC : BankAccount
    {
        // Fields specific to HSBC bank rules
        private const decimal MinimumWithdrawBalance = 5000;
        private const decimal MinimumTransferBalance = 5000;

        // Properties
        public override decimal Balance { get; protected set; }
        public override BankAccountTypeEnum BalanceType => BankAccountTypeEnum.Current;

        // Constructor
        public HSBC(int accountNumber, string accountHolderName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
        }

        // Methods
        public override double GetBalance()
        {
            return (double)Balance;
        }

        public override void Deposit(double amount)
        {
            Balance += (decimal)amount;
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
        }

        public override bool Withdraw(double amount)
        {
            if (Balance - (decimal)amount >= MinimumWithdrawBalance)
            {
                Balance -= (decimal)amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {Balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine($"Insufficient balance to withdraw {amount:C}. Current balance: {Balance:C}");
                return false;
            }
        }

        public override bool Transfer(IBankAccount toAccount, double amount)
        {
            if (Balance - (decimal)amount >= MinimumTransferBalance)
            {
                if (toAccount is BankAccount targetAccount)
                {
                    Balance -= (decimal)amount;
                    targetAccount.Deposit(amount);
                    Console.WriteLine($"Transferred {amount:C} to {targetAccount.AccountHolderName}. New balance: {Balance:C}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid target account for transfer.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Insufficient balance to transfer {amount:C}. Current balance: {Balance:C}");
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create ICICI saving and current accounts
            ICICI iciciSaving = new ICICI(123456, "John Doe", 50000);
            ICICI iciciCurrent = new ICICI(654321, "Jane Smith", 20000);

            // Print initial balances
            Console.WriteLine($"ICICI Saving Account Balance: {iciciSaving.Balance}");
            Console.WriteLine($"ICICI Current Account Balance: {iciciCurrent.Balance}");

            // Transfer Rs. 5000 from ICICI Saving to Current
            iciciSaving.Transfer(iciciCurrent, 5000);

            // Print balances after transfer
            Console.WriteLine("After transferring Rs. 5000 from ICICI Saving to Current:");
            Console.WriteLine($"ICICI Saving Account Balance: {iciciSaving.Balance}");
            Console.WriteLine($"ICICI Current Account Balance: {iciciCurrent.Balance}");

            // Create HSBC saving and current accounts
            HSBC hsbcSaving = new HSBC(111111, "Alice Johnson", 50000);
            HSBC hsbcCurrent = new HSBC(222222, "Bob Brown", 20000);

            // Print initial balances
            Console.WriteLine($"HSBC Saving Account Balance: {hsbcSaving.Balance}");
            Console.WriteLine($"HSBC Current Account Balance: {hsbcCurrent.Balance}");

            // Transfer Rs. 30000 from HSBC Saving to Current
            hsbcSaving.Transfer(hsbcCurrent, 30000);

            // Print balances after transfer
            Console.WriteLine("After transferring Rs. 30000 from HSBC Saving to Current:");
            Console.WriteLine($"HSBC Saving Account Balance: {hsbcSaving.Balance}");
            Console.WriteLine($"HSBC Current Account Balance: {hsbcCurrent.Balance}");

            Console.ReadKey();
        }
    }
}
