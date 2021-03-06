using FanthåmasBank.Models;
using System;
using Xunit;

namespace FanthåmasBank.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(900, 100, 1000)]
        [InlineData(100, 1000, 100)]
        [InlineData(960, 40, 1000)]
        public void Test_Withdraw(decimal expected, decimal withdrawAmount, decimal currentAmount)
        {
            BankRepository reposetory = new BankRepository();
            Account account = new Account() { AccountNumber = "123-3", Amount = currentAmount };

            decimal actual = reposetory.Withdraw(account, withdrawAmount);

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(1100, 100, 1000)]
        [InlineData(1100, 1000, 100)]
        [InlineData(1000, -123, 1000)]
        public void Test_Deposit(decimal expected, decimal depositAmount, decimal currentAmount)
        {
            BankRepository reposetory = new BankRepository();
            Account account = new Account() { AccountNumber = "123-22", Amount = currentAmount };

            decimal actual = reposetory.Deposit(account, depositAmount);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("Sender:900,Receiver:1100", 100, 1000, 1000)]
        [InlineData("Sender:100,Receiver:1000", 1000, 100, 1000)]
        [InlineData("Sender:1000,Receiver:1000", -123, 1000, 1000)]
        public void Test_Transfer(string expected, decimal transferAmount, decimal senderCurrentAmount, decimal receiverCurrentAmount)
        {
            BankRepository reposetory = new BankRepository();
            Account senderAccount = new Account() { AccountNumber = "123-transfer-senderAccount", Amount = senderCurrentAmount };
            Account receiverAccount = new Account() { AccountNumber = "123-transfer-receiverAccount", Amount = receiverCurrentAmount };
            string actual = reposetory.Transfer(senderAccount, receiverAccount, transferAmount);

            Assert.Equal(expected, actual);
        }
    }
}
