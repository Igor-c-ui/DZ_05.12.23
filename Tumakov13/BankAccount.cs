using System.Collections.Generic;
using System;
using System.IO;

namespace Tumakov13
{
    class BankAccount
    {
        public enum Type_bank_account
        {
            Текущий,
            Сберегательный
        }
        private static uint next_number_account = 1;
        private uint number_account;
        private decimal balance;
        private string holder;
        private Type_bank_account bank_account;
        private List<BankTransaction> transactions = new List<BankTransaction>();

        public string Holder
        {
            get { return holder; }
            set { holder = value; }
        }

        public uint Number_Account
        {
            get { return number_account; }
        }

        public decimal Balance_Account
        {
            get { return balance; }
        }

        public Type_bank_account Type_Bank_Account
        {
            get { return bank_account; }
        }

        public List<BankTransaction> Transactions
        {
            get { return transactions; }
        }

        public BankTransaction this[int index]
        {
            get
            {
                return transactions[index]; 
            }
        }

        private void Generate_next_number_account()
        {
            next_number_account++;
        }

        public static bool operator ==(BankAccount account1, BankAccount account2)
        {
            return ((account1.Number_Account == account2.Number_Account) && (account1.Balance_Account == account2.Balance_Account) && (account1.Type_Bank_Account == account2.Type_Bank_Account));
        }

        public static bool operator !=(BankAccount account1, BankAccount account2)
        {
            return ((account1.Type_Bank_Account != account2.Type_Bank_Account) && (account1.Number_Account != account2.Number_Account) && (account1.Balance_Account != account2.Balance_Account));
        }

        public override bool Equals(object obj)
        {
            if (obj is BankAccount bankAccount)
            {
                if ((bank_account == bankAccount.Type_Bank_Account) && (number_account == bankAccount.Number_Account) && (balance == bankAccount.Balance_Account))
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Тип: {bank_account}; №: {number_account}; Баланс: {balance}.";
        }

        public bool Withdraw(uint withdrawn_money)
        {
            if (balance - withdrawn_money > 0)
            {
                balance -= withdrawn_money;
                BankTransaction transaction = new BankTransaction(-withdrawn_money);
                transactions.Add(transaction);
                return true;
            }
            return false;
        }

        public void Put_Money(uint money)
        {
            balance += money;
            BankTransaction transaction = new BankTransaction(money);
            transactions.Add(transaction);
        }

        public bool Transfer_money(BankAccount account, decimal money)
        {
            if ((money > 0) && (balance - money > 0))
            {
                account.balance += money;
                balance -= money;
                BankTransaction transaction = new BankTransaction(-money);
                transactions.Add(transaction);
                return true;
            }
            return false;
        }

        public void Dispose(BankAccount bankAccount)
        {
            string file = "dispose.txt";
            int count = transactions.Count;

            for (int i = 0; i < count; i++)
            {
                BankTransaction transaction = transactions[i];
                transactions.RemoveAt(i);
                File.AppendAllText(file, $"\n{transaction.Withdrawn_Money}, {transaction.DateTime_Transaction}");
            }

            GC.SuppressFinalize(bankAccount);
        }

        internal BankAccount(decimal balance, Type_bank_account bank_account)
        {
            number_account = next_number_account;
            this.balance = balance;
            this.bank_account = bank_account;
            Generate_next_number_account();
        }

        internal BankAccount(decimal balance)
        {
            number_account = next_number_account;
            this.balance = balance;
            Generate_next_number_account();
        }

        internal BankAccount(Type_bank_account bank_account)
        {
            number_account = next_number_account;
            this.bank_account = bank_account;
            Generate_next_number_account();
        }
    }
}

