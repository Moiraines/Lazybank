namespace Lazybank.Services.Data
{
    using Lazybank.Data;
    using System.Linq;

    public interface INewsArticlesService
    {
        IQueryable<NewsArticle> GetAll();

        int Create(NewsArticle modelToSave);
    }
}
