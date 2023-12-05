using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Упр. 13.1
            BankAccount bankAccount = new BankAccount(1234, BankAccount.Type_bank_account.Сберегательный);
            Console.WriteLine($"№:{bankAccount.Number_Account}, {bankAccount.Type_Bank_Account}: {bankAccount.Balance_Account} $");

            //Упр. 13.2
            bankAccount.Put_Money(1234);
            Console.WriteLine(bankAccount[0].Withdrawn_Money);
        }
    }
}
