//namespace Lazybank.Web.Areas.Administration.Controllers
//{
//    using System;
//    using System.Linq;
//    using System.Web.Mvc;

//    using Kendo.Mvc.Extensions;
//    using Kendo.Mvc.UI;

//    using Microsoft.AspNet.Identity;

//    using Lazybank.Common;
//    using Lazybank.Data.Common;
//    using Lazybank.Data.Models;
//    using Lazybank.Web.Areas.Administration.ViewModels;
//    using Lazybank.Web.Controllers;
//    using Lazybank.Web.Infrastructure.Mapping;
//    using Lazybank.Web.ViewModels.Home;

//    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
//    public class AdministrationController : BaseController
//    {
//        private readonly IDbRepository<Joke> jokes;
//        private readonly IDbRepository<JokeCategory> categories;

//        public AdministrationController(IDbRepository<Joke> jokes, IDbRepository<JokeCategory> categories)
//        {
//            this.jokes = jokes;
//            this.categories = categories;
//        }

//        public ActionResult Index()
//        {
//            return this.View();
//        }

//        public ActionResult Jokes_Read([DataSourceRequest]DataSourceRequest request)
//        {
//            DataSourceResult result = this.jokes.All()
//                .To<JokeViewModel>()
//                .ToDataSourceResult(request);

//            return this.Json(result);
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult Jokes_Create([DataSourceRequest]DataSourceRequest request, JokeInputModel joke)
//        {
//            var newId = 0;
//            if (this.ModelState.IsValid)
//            {
//                var entity = new Joke
//                {
//                    Category = this.categories.All().FirstOrDefault(c => c.Name == joke.Category),
//                    Content = joke.Content
//                };

//                this.jokes.Add(entity);
//                this.jokes.Save();
//                newId = entity.Id;
//            }

//            var jokeToDisplay = this.jokes.All()
//                .To<JokeViewModel>()
//                .FirstOrDefault(x => x.Id == newId);
//            return this.Json(new[] { jokeToDisplay }.ToDataSourceResult(request, this.ModelState));
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult Jokes_Update([DataSourceRequest]DataSourceRequest request, JokeInputModel joke)
//        {
//            if (this.ModelState.IsValid)
//            {
//                var entity = this.jokes.GetById(joke.Id);
//                entity.Category = this.categories.All().FirstOrDefault(c => c.Name == joke.Category);
//                entity.Content = joke.Content;

//                this.jokes.Save();
//            }

//            var jokeToDisplay = this.jokes.All()
//                           .To<JokeViewModel>()
//                           .FirstOrDefault(x => x.Id == joke.Id);
//            return this.Json(new[] { jokeToDisplay }.ToDataSourceResult(request, this.ModelState));
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult Jokes_Destroy([DataSourceRequest]DataSourceRequest request, Joke joke)
//        {
//            this.jokes.Delete(joke);
//            this.jokes.Save();

//            return this.Json(new[] { joke }.ToDataSourceResult(request, this.ModelState));
//        }

//        [HttpPost]
//        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
//        {
//            var fileContents = Convert.FromBase64String(base64);

//            return this.File(fileContents, contentType, fileName);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            this.jokes.Dispose();
//            base.Dispose(disposing);
//        }
//    }
//}
