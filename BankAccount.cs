using System;
using System.Collections.Generic;
using System.Text;

namespace BankExample
{
    public class BankAccount
    {
        public string AccountNo { get; }
        public string Owner { get; set; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransitions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNoSeed = 1234567890; // private makes it accessible only to this class

        // static
        private List<Transaction> allTransitions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            Deposit(initialBalance, DateTime.Now, "Initial deposit");
            AccountNo = accountNoSeed.ToString();
            accountNoSeed++;
        }

        public void Deposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransitions.Add(deposit);
        }

        public void Withdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdraw must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Insufficient funds");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransitions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\tAmount\tNote");
            foreach (Transaction transaction in allTransitions)
            {
                // ROWS
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{transaction.Notes}");
            }
            return report.ToString();
        }
    }
}