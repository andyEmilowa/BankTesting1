    using NUnit.Framework;
using System;

namespace BankingSystem.Tests1
{
    [TestFixture]
    public class BankAccountTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DepositShouldIncreaseBalance()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = 100;

                bankAccount.Deposit(depositAmount);

                Assert.AreEqual(depositAmount, bankAccount.Balance);
            }
        }

        [Test]
        public void AccountInitializeWithPositiveValue()
        {
            {
                BankAccount bankAccount = new BankAccount(123, 2000m);

                Assert.AreEqual(2000m, bankAccount.Balance);
            }
        }

        [TestCase(100)]
        [TestCase(3500)]
        [TestCase(2400)]
        public void DepositShouldIncreaseBalanceAll(decimal depositAmount)
        {
            {
                BankAccount bankAccount = new BankAccount(123);

                bankAccount.Deposit(depositAmount);

                Assert.AreEqual(depositAmount, bankAccount.Balance);
            }
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptions()
        {

            {
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;

                Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
            }
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionWithMessage()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));

                Assert.AreEqual(ex.Message, "Negative amount");
            }
        }
        [Test]
        public void NegativeCashShouldThrowInvalidOperationExceptionWithMessage()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal cashCredit = -100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Credit(cashCredit));

                Assert.AreEqual(ex.Message, "Negative balance");
            }
        }

        [Test]

        public void PercentShouldBeAPositiveNumber()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                double percent = -100;

                var ex = Assert.Throws<ArgumentException>(() => bankAccount.Increase(percent));

                Assert.AreEqual(ex.Message, "The percent must be positive!");
            }
        }

        [Test]
        [TestCase(1500)]
        [TestCase(2500)]
        [TestCase(4000)]
        public void BonusShouldIncreaseBalanceInBankAccount(decimal bonusAmount)
        {
            {
                BankAccount bankAccount = new BankAccount(123);

                // bankAccount.Balance = bankAccount.Bonus();
                bankAccount.Balance = bankAccount.Bonus();

                Assert.AreEqual(bankAccount.Bonus(), bankAccount.Balance);
            }
        }
        [Test]
        public void PaymentForCreditShouldNotBeANegativeNumber()
        {

            {
                BankAccount bankAccount = new BankAccount(123);
                decimal payment = -100;

                // Assert.Throws<ArgumentException>(() => bankAccount.PaymentForCredit(payment));
                var ex = Assert.Throws<ArgumentException>(() => bankAccount.PaymentForCredit(payment));

                Assert.AreEqual(ex.Message, "Payment cannot be zero or negative!");
            }
        }
        [Test]
        public void PaymentForCreditShouldNotBeNull()
        {

            {
                BankAccount bankAccount = new BankAccount(123);
                decimal payment = 0;

                // Assert.Throws<ArgumentException>(() => bankAccount.PaymentForCredit(payment));
                var ex = Assert.Throws<ArgumentException>(() => bankAccount.PaymentForCredit(payment));

                Assert.AreEqual(ex.Message, "Payment cannot be zero or negative!");
            }
        }
        [Test]
        public void NotEnoughAmountInBalanceForPayment()
        {

            {
                BankAccount bankAccount = new BankAccount(123);
                decimal payment = 100;

                // Assert.Throws<ArgumentException>(() => bankAccount.PaymentForCredit(payment));
                var ex = Assert.Throws<ArgumentException>(() => bankAccount.PaymentForCredit(payment));

                Assert.AreEqual(ex.Message, "Not enough money!");
            }
        }
        [Test]
        public void BalanceMinusPaymentIfEnoughMoney()
        {
            BankAccount bankAccount = new BankAccount(123, 1000);

            bankAccount.Balance = bankAccount.PaymentForCredit(100);
            Assert.AreEqual(bankAccount.PaymentForCredit(100), bankAccount.Balance);
        }

    }
}






    