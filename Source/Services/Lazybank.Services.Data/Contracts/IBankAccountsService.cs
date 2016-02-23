using Lazybank.Data.Models;
using System.Linq;

namespace Lazybank.Services.Data
{
    public interface IBankAccountsService
    {
        IQueryable<BankAccount> GetAll();

        int Create(BankAccount modelToSave);

        int GetId(string name);
    }
}
