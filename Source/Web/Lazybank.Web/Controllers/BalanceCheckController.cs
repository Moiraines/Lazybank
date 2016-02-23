using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Lazybank.Services.Data;
using Lazybank.Web.Infrastructure.Mapping;
using Lazybank.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazybank.Web.Controllers
{
    public class BalanceCheckController : BaseController
    {
        private IUsersService users;
        private IBankAccountsService accounts;

        public BalanceCheckController(IUsersService users, IBankAccountsService accounts)
        {
            this.users = users;
            this.accounts = accounts;
        }

        // GET: BalanceCheck
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(userId);
            var viewModel = this.Mapper.Map<BalanceViewModel>(currentUser);

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
           // var currentClientId = request.Aggregates.
            var data = this.accounts.GetAll().Where(a => a.IndividualId == (int)this.TempData["currentClient"]);
            var result = data
                .ToDataSourceResult(request);

            return this.Json(result);
        }
    }
}