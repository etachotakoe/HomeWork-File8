using System;
using System.Collections;

public class BankAccount1
{
    private static int accountNumberCounter = 0;
    private readonly int accountNumber;
    private decimal balance;
    private string accountType;
    private Queue transactions;

    public BankAccount1()
    {
        this.accountNumber = GenerateAccountNumber();
        this.balance = 0;
        this.accountType = "Обычный";
        this.transactions = new Queue();
    }

    public BankAccount1(decimal initialBalance)
    {
        this.accountNumber = GenerateAccountNumber();
        this.balance = initialBalance;
        this.accountType = "Обычный";
        this.transactions = new Queue();
    }

    public BankAccount1(string accountType)
    {
        this.accountNumber = GenerateAccountNumber();
        this.balance = 0;
        this.accountType = accountType;
        this.transactions = new Queue();
    }

    public BankAccount1(decimal initialBalance, string accountType)
    {
        this.accountNumber = GenerateAccountNumber();
        this.balance = initialBalance;
        this.accountType = accountType;
        this.transactions = new Queue();
    }

    private static int GenerateAccountNumber()
    {
        return ++accountNumberCounter;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            transactions.Enqueue(new BankTransaction1(-amount));
            return true;
        }
        else
        {
            Console.WriteLine("Недостаточно средств для снятия.");
            return false;
        }
    }

    public void Deposit(decimal amount)
    {
        balance += amount;
        transactions.Enqueue(new BankTransaction1(amount));
    }

    public static bool Transfer(BankAccount1 fromAccount, BankAccount1 toAccount, decimal amount)
    {
        if (fromAccount.Withdraw(amount))
        {
            toAccount.Deposit(amount);
            return true;
        }
        return false;
    }

    public int AccountNumber => accountNumber;

    public decimal Balance => balance;

    public string AccountType => accountType;

    public override string ToString()
    {
        return $"Счет №{accountNumber}, Тип: {accountType}, Баланс: {balance:C}";
    }

    public Queue Transactions => transactions;
}
