using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferService
{
    public class AccountBalanceException : Exception
    {
        public AccountBalanceException(string message) : base(message)
        {
        }
    }
}
