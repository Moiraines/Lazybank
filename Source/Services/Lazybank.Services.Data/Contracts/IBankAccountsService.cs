namespace Lazybank.Services.Data
{
    using System.Linq;
    using Lazybank.Data.Models;

    public interface IBankAccountsService
    {
        IQueryable<BankAccount> GetAll();

        int Create(BankAccount modelToSave);

        int GetId(string name);

        BankAccount GetAccount(string name);

        void BalanceAccounts(BankAccount orderAcc, BankAccount benAcc, decimal transferSum);
    }
}
