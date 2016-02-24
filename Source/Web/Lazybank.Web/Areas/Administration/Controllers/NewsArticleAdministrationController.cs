namespace Lazybank.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using ViewModels;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class NewsArticleAdministrationController : BaseController
    {
        private INewsArticlesService articles;

        public NewsArticleAdministrationController(INewsArticlesService articles)
        {
            this.articles = articles;
        }

        // GET: Administration/NewsArticleAdministration
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var gridArticles = this.articles.GetAll().To<NewsArticleViewModel>().ToList();
            var result = gridArticles.ToDataSourceResult(request);

            return this.Json(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, NewsArticleViewModel article)
        {
            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var newArticle = new NewsArticle
                {
                    Content = article.Content,
                    ImageUrl = article.ImageUrl,
                    Title = article.Title
                };

                this.articles.Create(newArticle);
                newId = newArticle.Id;
            }

            var articleToDisplay = this.articles.GetAll()
            .To<NewsArticleViewModel>()
            .FirstOrDefault(x => x.Id == newId);
            return this.Json(new[] { articleToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, NewsArticleViewModel article)
        {
            if (this.ModelState.IsValid)
            {
               var updatedArticle = this.articles.GetById(article.Id);
                updatedArticle.Content = article.Content;
                updatedArticle.ImageUrl = article.ImageUrl;
                updatedArticle.Title = article.Title;

                this.articles.Save();
            }

            var articleToDisplay = this.articles.GetAll()
                          .To<NewsArticleViewModel>()
                          .FirstOrDefault(x => x.Id == article.Id);
           return this.Json(new[] { articleToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, NewsArticle article)
        {
            this.articles.Delete(article);
            this.articles.Save();

             return this.Json(new[] { article }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
