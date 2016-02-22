namespace Lazybank.Web.Areas.Public.Controllers
{
    using System;
    using System.Web.Mvc;

    using Lazybank.Data.Models;
    using Lazybank.Services.Data;
    using Lazybank.Web.Controllers;
    using Lazybank.Web.ViewModels;
    using Microsoft.AspNet.Identity;

    public class FeedbacksController : BaseController
    {
        private IFeedbacksService feedbacks;

        public FeedbacksController(IFeedbacksService feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var newFeedback = this.Mapper.Map<Feedback>(model);
            newFeedback.CreatedOn = DateTime.Now;

            if (this.User.Identity.IsAuthenticated)
            {
                newFeedback.AuthorId = this.User.Identity.GetUserId();
            }

            this.feedbacks.Create(newFeedback);

            this.TempData["Notification"] = "Thank you for your feedback!";
            return this.Redirect("/");
        }
    }
}