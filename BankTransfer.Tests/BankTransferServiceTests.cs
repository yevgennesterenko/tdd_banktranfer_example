using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankTransferService;
using NUnit.Framework;
using TDD.Examples.Solved;

namespace BankTransfer.Tests
{
    public class BankTransferServiceTests
    {
        //from one account to another? what is account? account is entity
        //need to create account somehow? need to deposit account somehow?
        [Test]
        public void GivenNewAccountId_WhenCreateAnAccount_ThenAccountWithZeroBalanceShouldBeCreated()
        {
            //arrange
            int accountId = 1;
            //act
            var account = new CustomerAccount(accountId);
            //assert
            Assert.AreEqual(account.Balance,0);
        }

        [Test]
        public void GivenExistingAccount_WhenDepositMoneyToAccount_ThenAccountBalanceShouldBeEqualMoneyDeposited()
        {
            //arrange
            int accountId = 1;
            var account = new CustomerAccount(accountId);
            int moneyToDeposit = 100;
            //act
            account.Deposit(moneyToDeposit);
            //assert
            Assert.AreEqual(account.Balance, moneyToDeposit);
        }


        //sad path scenario 1
        [Test]
        public void GivenExistingAccount_WhenWithdrawMoreMoneyFromAccountThenBalance_ThenAccountBalanceStayTheSame()
        {
            //arrange
            int accountId = 1;
            var account = new CustomerAccount(accountId);
            int moneyToWithdraw = 100;        
            account.Deposit(30);
            decimal accountPreviousBalace = account.Balance;
            //act        
            Assert.Throws<AccountBalanceException>(() => account.Withdraw(moneyToWithdraw));
            //assert
            Assert.That(account.Balance, Is.EqualTo(accountPreviousBalace));
        }

        //sad path scenario 2        
        [Test]
        public void GivenExistingAccount_WhenWithdrawMoreMoneyFromAccountThenBalance_ThenAccountBalanceExceptionIsGeneratedWithPredefinedMessage()
        {
            //arrange
            int accountId = 1;
            var account = new CustomerAccount(accountId);
            int moneyToWithdraw = 100;
            account.Deposit(30);            
            //act        
            AccountBalanceException ex = Assert.Throws<AccountBalanceException>(() => account.Withdraw(moneyToWithdraw));   
            //assert
            Assert.That(ex.Message, Is.EqualTo("Not enough money on account!"));                        
        }


        //happy path scenario
        [Test]
        public void GivenExistingAccount_WhenWithdrawMoneyFromAccount_ThenAccountBalanceShouldChangeAccordingly()
        {
            //arrange
            int accountId = 1;
            var account = new CustomerAccount(accountId);
            int moneyToWithdraw = 100;
             account.Deposit(moneyToWithdraw);
            //act
            decimal accountPreviousBalance = account.Balance;
            account.Withdraw(moneyToWithdraw);
            //assert
            Assert.AreEqual( moneyToWithdraw,  accountPreviousBalance - account.Balance);
        }
    }

    
}
