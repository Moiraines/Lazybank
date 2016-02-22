namespace Lazybank.Services.Data
{
    using System.Linq;

    using Lazybank.Data;
    using Lazybank.Data.Common;

    public class NewsArticlesService : INewsArticlesService
    {
        private readonly IDbRepository<NewsArticle> articles;

        public NewsArticlesService(IDbRepository<NewsArticle> articles)
        {
            this.articles = articles;
        }

        public int Create(NewsArticle modelToSave)
        {
            this.articles.Add(modelToSave);
            this.articles.Save();

            return modelToSave.Id;
        }

        public IQueryable<NewsArticle> GetAll()
        {
            return this.articles.All();
        }
    }
}
