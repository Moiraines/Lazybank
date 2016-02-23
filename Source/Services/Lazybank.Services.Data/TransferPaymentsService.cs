using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lazybank.Data.Models;
using Lazybank.Data.Common;

namespace Lazybank.Services.Data
{
    public class TransferPaymentsService : ITransferPaymentsService
    {
        private readonly IDbRepository<TransferPayment> transferPayments;

        public TransferPaymentsService(IDbRepository<TransferPayment> transferPayments)
        {
            this.transferPayments = transferPayments;
        }

        public int Create(TransferPayment modelToSave)
        {
            this.transferPayments.Add(modelToSave);
            this.transferPayments.Save();

            return modelToSave.Id;
        }

        public IQueryable<TransferPayment> GetAll()
        {
            return this.transferPayments.All();
        }

        public TransferPayment GetById(int id)
        {
            return this.transferPayments.GetById(id);
        }
    }
}
