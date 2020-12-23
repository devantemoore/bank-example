using System;
using System.Collections.Generic;
using System.Text;

namespace BankExample
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Notes = note;
        }
    }
}