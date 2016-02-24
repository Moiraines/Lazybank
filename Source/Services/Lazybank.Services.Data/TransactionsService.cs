namespace Lazybank.Services.Data
{
    using System.Linq;
    using Lazybank.Data.Common;
    using Lazybank.Data.Models;

    public class TransactionsService : ITransactionsService
    {
        private readonly IDbRepository<Transaction> transactions;

        public TransactionsService(IDbRepository<Transaction> transactions)
        {
            this.transactions = transactions;
        }

        public int Create(Transaction modelToSave)
        {
            this.transactions.Add(modelToSave);
            this.transactions.Save();

            return modelToSave.Id;
        }

        public IQueryable<Transaction> GetAll()
        {
            return this.transactions.All();
        }

        public Transaction GetById(int id)
        {
            return this.transactions.GetById(id);
        }
    }
}
