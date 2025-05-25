using System;

public class BankAccount
{
    string AccountHolderName { get; set; }
    decimal Balance { get; private set; }

    public BankAccount(string accountHolderName, decimal initialBalance)
    {
        AccountHolderName = accountHolderName;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited ₹{amount} in cash. New Balance: ₹{Balance}");
    }

    public void Deposit(string checkNumber, decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited ₹{amount} using Check #{checkNumber}. New Balance: ₹{Balance}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew ₹{amount} in cash. Remaining Balance: ₹{Balance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance for cash withdrawal.");
        }
    }

    public void Withdraw(string checkNumber, decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew ₹{amount} using Check #{checkNumber}. Remaining Balance: ₹{Balance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance for check withdrawal.");
        }
    }
}
BankAccount account = new BankAccount("Yagnik", 1000m);

account.Deposit(500m);                    
account.Deposit("CHK12345", 1500m);       

account.Withdraw(300m);                 
account.Withdraw("CHK54321", 700m);  