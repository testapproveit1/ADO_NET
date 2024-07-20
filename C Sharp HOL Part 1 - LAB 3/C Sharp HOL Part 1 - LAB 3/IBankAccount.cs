using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_HOL_Part_1___LAB_3
{
    public interface IBankAccount
    {
        int AccountNumber { get; }
        string AccountHolderName { get; set; }
        decimal Balance { get; }

        // Methods
        double GetBalance();
        void Deposit(double amount);    
        bool Withdraw(double amount);
        bool Transfer(IBankAccount toAccount, double amount);
        BankAccountTypeEnum BalanceType { get; }

    }

}
