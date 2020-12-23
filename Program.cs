using System;

namespace BankExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var account = new BankAccount("DeVante", 1200000);
            Console.WriteLine($"Account {account.AccountNo} was created for {account.Owner} with a balance of: {account.Balance}");
            account.Deposit(1400, DateTime.Now, "Just got pizaaiiiddd");
            Console.WriteLine(account.Balance);

            account.Withdrawal(1000, DateTime.Now, "Bills");
            Console.WriteLine(account.Balance);

            account.Withdrawal(200, DateTime.Now, "Capital Expenditure");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}