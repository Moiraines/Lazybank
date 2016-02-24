namespace Lazybank.Services.Data
{
    using System;
    using System.Linq;
    using Lazybank.Data.Common;
    using Lazybank.Data.Models;

    public class BankAccountsService : IBankAccountsService
    {
        private readonly IDbRepository<BankAccount> accounts;

        public BankAccountsService(IDbRepository<BankAccount> accounts)
        {
            this.accounts = accounts;
        }

        public IQueryable<BankAccount> GetAll()
        {
            return this.accounts.All();
        }

        public int Create(BankAccount modelToSave)
        {
            throw new NotImplementedException();
        }

        public int GetId(string name)
        {
            var account = this.accounts.All().FirstOrDefault(x => x.Number == name);

            return account.Id;
        }

        public BankAccount GetAccount(string name)
        {
            var account = this.accounts.All().FirstOrDefault(x => x.Number == name);

            return account;
        }

        public void BalanceAccounts(BankAccount orderAcc, BankAccount benAcc, decimal transferSum)
        {
            orderAcc.Balance = orderAcc.Balance - transferSum;
            benAcc.Balance = benAcc.Balance + transferSum;
        }
    }
}
