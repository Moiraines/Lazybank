using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lazybank.Data.Models;
using Lazybank.Data.Common;

namespace Lazybank.Services.Data
{
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
