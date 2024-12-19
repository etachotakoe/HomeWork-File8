using System;

public class BankTransaction1
{
    public DateTime TransactionDate { get; }
    public decimal Amount { get; }

    public BankTransaction1(decimal amount)
    {
        TransactionDate = DateTime.Now;
        Amount = amount;
    }
}
