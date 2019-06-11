using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using MyCurrencyPocketbook.Models;

namespace MyCurrencyPocketbook.Services
{
    public class PocketAccountService
    {
        private IApplicationDbContext db;

        public PocketAccountService(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void CreatePocketAccount(string firstName, string lastName, string userId, decimal initialBalance)
        {
            var accountNo = (1234 + db.PocketAccounts.Count().ToString().PadLeft(10, '0'));
            var pocketAccount = new PocketAccount
            {
                FirstName = firstName,
                LastName = lastName,
                PocketAccountNumber = accountNo,
                Balance = initialBalance,
                ApplicationUserId = userId
            };

            try
            {
                db.PocketAccounts.Add(pocketAccount);
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        public void UpdateBalance(int pocketAccountId)
        {
            var pocketAccount = db.PocketAccounts.
                Where(c => c.Id == pocketAccountId).First();
            pocketAccount.Balance = db.Transactions.
                Where(c => c.PocketAccountId == pocketAccountId).Sum(c => c.Amount);

            db.SaveChanges();
        }

    }
}