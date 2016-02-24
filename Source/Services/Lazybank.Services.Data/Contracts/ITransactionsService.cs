namespace Lazybank.Services.Data
{
    using System.Linq;
    using Lazybank.Data.Models;

    public interface ITransactionsService
    {
        IQueryable<Transaction> GetAll();

        Transaction GetById(int id);

        int Create(Transaction modelToSave);
    }
}
