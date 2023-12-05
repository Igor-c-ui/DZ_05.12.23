using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Упр. 14.1
            BankAccount bankAccount = new BankAccount(13243, BankAccount.Type_bank_account.Текущий);
            DumpToScreen.Method(bankAccount);

            //Упр. 14.2
            MemberInfo attrInfo = typeof(RationalNumber);
            object[] attrs = attrInfo.GetCustomAttributes(false);
            DeveloperInfoAttribute developerInfo = (DeveloperInfoAttribute)attrs[0];
            Console.WriteLine($"{developerInfo.Name}, {developerInfo.Datetime}");
        }
    }
}
