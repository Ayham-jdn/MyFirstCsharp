using System;
using System.Collections.Generic;
using System.Transactions;

namespace MyFirstProgram
{
    public class BankAccount
    {
        public required string AccountNumber { get; set; }
        public required string Password { get; set; }
        public required string AccountCurrency { get; set; }
        public decimal Balance { get; set; }

        
        private List<Transaction> Transactions { get; } = new List<Transaction>();

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid transaction.");
                Console.Beep();
            }
            else if (amount > Balance)
            {
                Console.WriteLine("The balance is insufficient.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn amount: {amount} {AccountCurrency}");
                Console.WriteLine($"New balance for account {AccountNumber}: {Balance} {AccountCurrency}");

                Transactions.Add(new Transaction
                {
                    Type = "Withdraw",
                    Amount = amount,
                    Currency = AccountCurrency,
                    Date = DateTime.Now
                });
            }
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposit amount: {amount} {AccountCurrency}");
            Console.WriteLine($"New balance for account {AccountNumber}: {Balance} {AccountCurrency}");

            Transactions.Add(new Transaction
            {
                Type = "Deposit",
                Amount = amount,
                Currency = AccountCurrency,
                Date = DateTime.Now
            });
        }

        public void Transfer(BankAccount toAccount, decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("The balance is insufficient.");
                Console.Beep();
                return;
            }

            Balance -= amount;
            toAccount.Balance += amount;
            Console.WriteLine($"Successfully transferred {amount} {AccountCurrency} to account {toAccount.AccountNumber}");

            Transactions.Add(new Transaction
            {
                Type = "Transfer (Sent)",
                Amount = amount,
                Currency = AccountCurrency,
                Date = DateTime.Now,
                Notes = $"To {toAccount.AccountNumber}"
            });

            toAccount.Transactions.Add(new Transaction
            {
                Type = "Transfer (Received)",
                Amount = amount,
                Currency = toAccount.AccountCurrency,
                Date = DateTime.Now,
                Notes = $"From {AccountNumber}"
            });
        }

        public void BankStatement()
        {
            Console.WriteLine($"=== Bank Statement for Account {AccountNumber} ===");
            Console.WriteLine($"Current Balance: {Balance} {AccountCurrency}");
            Console.WriteLine("Transaction History:");

            foreach (var tx in Transactions)
            {
                Console.WriteLine(tx);
            }

            Console.WriteLine("=====================================");
        }
    }
}
