#define DEBUG_ACCOUNT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov14
{
    internal class DumpToScreen
    {
        public static void Method(BankAccount bankAccount)
        {
            bankAccount.DumpToScreen();
        }
    }
}
