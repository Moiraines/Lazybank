namespace Lazybank.Web.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Lazybank.Services.Data;
    using Lazybank.Web.Infrastructure.Mapping;
    using Lazybank.Web.ViewModels;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class BalanceCheckController : BaseController
    {
        private IUsersService users;

        public BalanceCheckController(IUsersService users)
        {
            this.users = users;
        }

        // GET: BalanceCheck
        [OutputCache(Duration = 2 * 60)]
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(userId);
            var viewModel = this.Mapper.Map<BalanceViewModel>(currentUser);

            return this.View(viewModel);
        }
    }
}
