using System;

public enum AccountType
{
    Savings,
    Current
}

public class BankAccount
{
    private static int accountNumberCounter = 0; 
    private readonly int accountNumber; 
    private decimal balance; 
    private AccountType accountType; 

    public BankAccount()
    {
        this.accountNumber = GenerateAccountNumber();
        this.balance = 0;
        this.accountType = AccountType.Savings; 
    }

    public BankAccount(decimal initialBalance) : this()
    {
        this.balance = initialBalance;
    }

    public BankAccount(AccountType type) : this()
    {
        this.accountType = type;
    }

    public BankAccount(decimal initialBalance, AccountType type) : this()
    {
        this.balance = initialBalance;
        this.accountType = type;
    }
    private static int GenerateAccountNumber()
    {
        return ++accountNumberCounter;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Сумма должна быть положительной.");
        }
        balance += amount;
        Console.WriteLine($"Пополнение на сумму: {amount}. Новый баланс: {balance}");
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Сумма должна быть положительной.");
        }
        if (amount > balance)
        {
            Console.WriteLine("Недостаточно средств на счете.");
            return false; 
        }
        balance -= amount;
        Console.WriteLine($"Снятие суммы: {amount}. Остаток на счете: {balance}");
        return true; 
    }

    public static void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
    {
        if (fromAccount.Withdraw(amount)) 
        {
            toAccount.Deposit(amount); 
            Console.WriteLine($"Перевод суммы: {amount} с счета {fromAccount.accountNumber} на счет {toAccount.accountNumber} выполнен успешно.");
        }
        else
        {
            Console.WriteLine("Перевод не выполнен из-за недостатка средств.");
        }
    }

    
    public int AccountNumber => accountNumber;
    public decimal Balance => balance;
    public AccountType AccountType => accountType;
}
