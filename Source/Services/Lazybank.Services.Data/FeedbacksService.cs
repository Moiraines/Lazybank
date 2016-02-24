namespace Lazybank.Services.Data
{
    using System;
    using System.Linq;

    using Lazybank.Data.Common;
    using Lazybank.Data.Models;

    public class FeedbacksService : IFeedbacksService
    {
        private readonly IDbRepository<Feedback> feedbacks;

        public FeedbacksService(IDbRepository<Feedback> feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        public int Create(Feedback modelToSave)
        {
            this.feedbacks.Add(modelToSave);
            this.feedbacks.Save();

            return modelToSave.Id;
        }

        public IQueryable<Feedback> GetAll()
        {
            return this.feedbacks.All();
        }

        public Feedback GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
