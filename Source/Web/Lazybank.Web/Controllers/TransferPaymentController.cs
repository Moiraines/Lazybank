using Lazybank.Services.Data;
using Lazybank.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazybank.Web.Controllers
{
    [Authorize]
    public class TransferPaymentController : BaseController
    {
        private IUsersService users;

        public TransferPaymentController(IUsersService users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var userId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(userId);
            var viewModel = this.Mapper.Map<BalanceViewModel>(currentUser);

            return this.View(viewModel);
        }
    }
}