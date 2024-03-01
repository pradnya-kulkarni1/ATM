using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class BankAccount
    {
        private decimal _balanceamount;
        private static int instanceCount = 0;
        int accountno = 100;
        public BankAccount()
        {
            instanceCount++;
            accountno = accountno + instanceCount;
        }
        public int AccountNo { get {return accountno; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal StartingBalance { get; set; }

        public decimal NewBalance { get { return _balanceamount; } }
        public decimal Makedeposit (decimal amt)
        {
            return _balanceamount + amt;
        } 
        public decimal MakeWithDrawal (decimal amt)
        {
            if (amt< _balanceamount)
            {
                _balanceamount -= amt;
                return _balanceamount;
            }
            else
            {
                throw new Exception("Insufficient Funds, You cannot withdraw!");
            }
        }
    }
}
