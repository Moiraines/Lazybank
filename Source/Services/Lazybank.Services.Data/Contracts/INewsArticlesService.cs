namespace Lazybank.Services.Data
{
    using System.Linq;
    using Lazybank.Data;

    public interface INewsArticlesService
    {
        IQueryable<NewsArticle> GetAll();

        int Create(NewsArticle modelToSave);
    }
}
