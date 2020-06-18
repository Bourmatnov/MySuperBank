using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; }
        public decimal Balance {
            get {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        private static int accountseed = 12175;
        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name,decimal initialBalance)
        {
            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Deposit");
            Number = accountseed.ToString();
            accountseed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be posititve");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount withdrawn must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient Funds for Withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHist()
        {
            var histreport = new StringBuilder();
            histreport.AppendLine("Date\t\t\tAmount\tNote");
            histreport.AppendLine();
            foreach (var item in allTransactions)
            {
                histreport.AppendLine($"{item.Date.ToShortDateString()}\t\t${item.Amount}\t {item.Notes}");
            }
            return histreport.ToString();
        }

    }
}
