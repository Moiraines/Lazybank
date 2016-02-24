namespace Lazybank.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Services.Data;
    using Web.Controllers;
    using Kendo.Mvc.UI;
    using Infrastructure.Mapping;
    using System.Linq;
    using ViewModels;
    using Kendo.Mvc.Extensions;
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
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, NewsArticleViewModel model)
        {
            if (this.ModelState.IsValid)
            {

            }

            return this.Json(new object[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([DataSourceRequest]DataSourceRequest request, NewsArticleViewModel model)
        {
            if (this.ModelState.IsValid)
            {

            }

            return this.Json(new object[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, NewsArticleViewModel model)
        {
            // delete
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
