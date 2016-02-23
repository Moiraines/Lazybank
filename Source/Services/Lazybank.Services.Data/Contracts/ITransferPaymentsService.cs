namespace Lazybank.Services.Data
{
    using System.Linq;
    using Lazybank.Data.Models;

    public interface ITransferPaymentsService
    {
        IQueryable<TransferPayment> GetAll();

        TransferPayment GetById(int id);

        int Create(TransferPayment modelToSave);
    }
}
