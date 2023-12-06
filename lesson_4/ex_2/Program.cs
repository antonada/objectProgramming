using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_2
{
    abstract class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public abstract void ProcessTransaction();
    }

    class Account
    {
        private List<Transaction> transactions = new List<Transaction>();
        public static decimal TotalIncome { get; set; }
        public static decimal TotalExpenses { get; set; }

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
            transaction.ProcessTransaction();
        }

        public void DisplayOverallTotal()
        {
            Console.WriteLine($"Total Income: {TotalIncome}");
            Console.WriteLine($"Total Expenses: {TotalExpenses}");
        }
    }

    class ExpenseTransaction : Transaction
    {
        public override void ProcessTransaction()
        {
            Account.TotalExpenses += Amount;
        }
    }

    class IncomeTransaction : Transaction
    {
        public override void ProcessTransaction()
        {
            Account.TotalIncome += Amount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();

            IncomeTransaction income1 = new IncomeTransaction { Amount = 1000, TransactionDate = DateTime.Now };
            ExpenseTransaction expense1 = new ExpenseTransaction { Amount = 500, TransactionDate = DateTime.Now.AddDays(1) };
            IncomeTransaction income2 = new IncomeTransaction { Amount = 2000, TransactionDate = DateTime.Now.AddDays(2) };
            ExpenseTransaction expense2 = new ExpenseTransaction { Amount = 800, TransactionDate = DateTime.Now.AddDays(3) };

            account.AddTransaction(income1);
            account.AddTransaction(expense1);
            account.AddTransaction(income2);
            account.AddTransaction(expense2);

            account.DisplayOverallTotal();
        }
    }
}
