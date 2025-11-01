using MyFirstProgram;
using System.Runtime.Serialization;


BankAccount acc1 = new BankAccount
{
    AccountNumber = "DE01001020",
    AccountCurrency = "USD",
    Password = "Pass1",
    Balance = 1000
};

BankAccount acc2 = new BankAccount
{
    AccountNumber = "DE01001021",
    AccountCurrency = "EGY",
    Password = "Pass2",
    Balance = 500
};

Messsages.Hello();

acc1.Deposit(200);
acc1.Withdraw(300);
acc1.Transfer(acc2, 400);
acc1.BankStatement();
acc2.BankStatement();

Messsages.Bye();



