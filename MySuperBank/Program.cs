using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary;

namespace MySuperbank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initial account create
                var account = new BankAccount("Kendra", 10000);
                Console.WriteLine($"Account {account.Number} was created for {account.Owner} with Balance of {account.Balance}!!!");
                //Console.WriteLine($"Current DateTime is {DateTime.Now}");

                // Make a valid withdrawal
                account.MakeWithdrawal(120, Convert.ToDateTime("6/15/2020 8:51:05 AM"), "Sleeping Bag");
                //Console.WriteLine(account.Balance);

                // try to break by sending in negative deposit
                //account.MakeDeposit(-200, DateTime.Now, "Steal");

                // try to withdraw negative
                //account.MakeWithdrawal(-200, DateTime.Now, "negative amount withdrawal");

                // try to overdraw
                //account.MakeWithdrawal(3445200, DateTime.Now, "New House");

                // Deposit
                account.MakeDeposit(450, DateTime.Now, "Extra Cash");

                // Acceptable withdrawal
                account.MakeWithdrawal(35, DateTime.Now, "Need cash");

                Console.WriteLine(account.GetAccountHist());
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception: Negative deposit!");
                Console.WriteLine(e.ToString());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception: You cannot overdraw this account!");
                Console.WriteLine(e.ToString());
            }
            catch
            {
                Console.WriteLine("Unknown Exception caught!");
            }
            Console.ReadLine();

        }
    }
}
