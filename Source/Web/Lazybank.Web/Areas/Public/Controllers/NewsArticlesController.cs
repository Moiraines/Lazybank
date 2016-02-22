using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Lazybank.Common;
using Lazybank.Services.Data;
using Lazybank.Web.ViewModels;
using Lazybank.Web.Controllers;
using Lazybank.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lazybank.Data;
using Lazybank.Services.Web;
using Microsoft.AspNet.Identity;

namespace Lazybank.Web.Areas.Public.Controllers
{
    public class NewsArticlesController : BaseController
    {
        private const int ItemsPerPage = 3;
        private INewsArticlesService articles;

        public NewsArticlesController(INewsArticlesService articles)
        {
            this.articles = articles;
        }

        // GET: Public/News
        public ActionResult Index()
        {
            var articles = this.articles.GetAll()
                .OrderBy(x => x.CreatedOn)
                .ThenBy(x => x.Id)
                .To<NewsArticleViewModel>().ToList();

            return this.View(articles);
        }

        // GET: Public/Details
        public ActionResult Details(int id)
        {
            var newsFromDb = this.articles.GetAll().Where(x => x.Id == id).FirstOrDefault();
            if (newsFromDb == null)
            {
                return this.RedirectToAction("NotFound");
            }

            var newsDetails = this.Mapper.Map<NewsArticleViewModel>(newsFromDb);

            return this.View(newsDetails);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsArticleInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (model.File != null)
            {
                model.ImageUrl = new NewsArticleImageUploadProvider().Save(this.Server, model.File);
            }

            var newArticle = this.Mapper.Map<NewsArticle>(model);
            newArticle.CreatedOn = DateTime.Now;
            var userId = this.User.Identity.GetUserId();
            newArticle.AuthorId = userId;
            int id = this.articles.Create(newArticle);
            return this.RedirectToAction("Details", "NewsArticles", new { id = id, name = model.Title });
        }
    }
}