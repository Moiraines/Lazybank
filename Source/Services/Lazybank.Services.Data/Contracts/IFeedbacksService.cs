namespace Lazybank.Services.Data
{
    using System.Linq;

    using Lazybank.Data.Models;

    public interface IFeedbacksService
    {
        IQueryable<Feedback> GetAll();

        Feedback GetById(int id);

        int Create(Feedback modelToSave);
    }
}
