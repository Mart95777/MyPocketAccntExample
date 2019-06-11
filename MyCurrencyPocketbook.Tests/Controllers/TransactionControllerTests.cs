using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCurrencyPocketbook.Controllers;
using MyCurrencyPocketbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCurrencyPocketbook.Tests.Controllers
{
    [TestClass]
    public class TransactionControllerTests
    {
        [TestMethod]
        public void BalanceAfterAddToPocket()
        {
            var fakeDb = new FakeApplicationDbContext();
            fakeDb.PocketAccounts = new FakeDbSet<PocketAccount>();

            var pocketAccount = new PocketAccount
            {
                Id = 1,
                PocketAccountNumber = "0001234567",
                Balance = 0
            };
            fakeDb.PocketAccounts.Add(pocketAccount);

            fakeDb.Transactions = new FakeDbSet<Transaction>();
            var transactionController = new TransactionController(fakeDb);

            // Act
            transactionController.AddToPocket(new Transaction { PocketAccountId = 1, Amount = 73.8m });
            // hardcode check the test for TDD
            //pocketAccount.Balance = 73.8m;
            //pocketAccount.Balance = 0.8m;

            // Assert
            Assert.AreEqual(73.8m, pocketAccount.Balance);
        }
    }
}
