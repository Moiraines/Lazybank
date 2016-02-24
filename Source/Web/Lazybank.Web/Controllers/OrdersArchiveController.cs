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
    public class OrdersArchiveController : BaseController
    {
        private IUsersService users;
        private ITransferPaymentsService transferPayments;
        private IList<TransferPaymentViewModel> payments;

        public OrdersArchiveController(IUsersService users, IList<TransferPaymentViewModel> payments, ITransferPaymentsService transferPayments)
        {
            this.users = users;
            this.payments = payments;
            this.transferPayments = transferPayments;
        }

        // GET: BalanceCheck
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var currentTransferPayments = this.transferPayments.GetAll().Where(x => x.UserId == userId);

            foreach (var payment in currentTransferPayments)
            {
                var temp = this.Mapper.Map<TransferPaymentViewModel>(payment);
                this.payments.Add(temp);
            }

            var viewModel = this.payments;

            return this.View(viewModel);
        }
    }
}