using System;

class Program
{
    static void Main()
    {
        Task1();
        Task2();
    }
    static void Task1()
    {
        Console.WriteLine("Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить\r\nметоды заполнения полей. Вместо этих методов создать конструкторы. Переопределить\r\nконструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор\r\nдля заполнения поля тип банковского счета, конструктор для заполнения баланса и типа\r\nбанковского счета. Каждый конструктор должен вызывать метод, генерирующий номер\r\nсчета.");
        
        BankAccount account1 = new BankAccount(1000m, AccountType.Current);
        BankAccount account2 = new BankAccount(500m, AccountType.Savings);

        account1.Deposit(200m);

        account1.Withdraw(300m);

       
        BankAccount.Transfer(account1, account2, 400m);

       
        BankAccount.Transfer(account1, account2, 1000m);

        Console.WriteLine($"Баланс счета 1: {account1.Balance}");
        Console.WriteLine($"Баланс счета 2: {account2.Balance}");
        Console.ReadLine(); 
    }

    static void Task2()
    {
        Console.WriteLine("\n\nУпражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию\r\nо всех банковских операциях. При изменении баланса счета создается новый объект класса\r\nBankTransaction, который содержит текущую дату и время, добавленную или снятую со\r\nсчета сумму. Поля класса должны быть только для чтения (readonly). Конструктору класса\r\nпередается один параметр – сумма. В классе банковский счет добавить закрытое поле типа\r\nSystem.Collections.Queue, которое будет хранить объекты класса BankTransaction для\r\nданного банковского счета; изменить методы снятия со счета и добавления на счет так,\r\nчтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в\r\nпеременную типа System.Collections.Queue.");
        BankAccount1 account1 = new BankAccount1(1000, "Сберегательный");
        BankAccount1 account2 = new BankAccount1(500, "Текущий");

        Console.WriteLine(account1);
        Console.WriteLine(account2);

        account1.Deposit(500);
        Console.WriteLine("После пополнения:");
        Console.WriteLine(account1);

        if (account1.Withdraw(200))
        {
            Console.WriteLine("Снятие прошло успешно.");
        }
        Console.WriteLine(account1);

        if (BankAccount1.Transfer(account1, account2, 300))
        {
            Console.WriteLine("Перевод прошел успешно.");
        }
        else
        {
            Console.WriteLine("Перевод не удался.");
        }

        Console.WriteLine("Итоговые состояния счетов:");
        Console.WriteLine(account1);
        Console.WriteLine(account2);

        Console.WriteLine("Транзакции для первого счета:");
        foreach (BankTransaction1 transaction in account1.Transactions)
        {
            Console.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount:C}");
        }

        Console.WriteLine("Транзакции для второго счета:");
        foreach (BankTransaction1 transaction in account2.Transactions)
        {
            Console.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount:C}");
        }
    }
}
