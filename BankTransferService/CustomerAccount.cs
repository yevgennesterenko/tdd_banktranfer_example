using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTransferService;

namespace TDD.Examples.Solved
{
    public class CustomerAccount
    {
        private int accountId;

        public CustomerAccount(int accountId)
        {
            this.accountId = accountId;
        }

        public decimal Balance { get; set; }

        public void Deposit(int moneyToDeposit)
        {
            this.Balance += moneyToDeposit;
        }

        public void Withdraw(int moneyToWithdraw)
        {
            if (this.Balance < moneyToWithdraw)
            {
                throw new AccountBalanceException("Not enough money on account!");
            }
            this.Balance -= moneyToWithdraw;
        }
    }
}
