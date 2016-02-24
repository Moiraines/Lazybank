namespace Lazybank.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Lazybank.Services.Data;
    using Lazybank.Web.ViewModels;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class TransactionCheckController : BaseController
    {
        private IUsersService users;
        private ITransactionsService transactions;
        private IList<TransactionViewModel> tempTransactions;

        public TransactionCheckController(IUsersService users, IList<TransactionViewModel> tempTransactions, ITransactionsService transactions)
        {
            this.users = users;
            this.tempTransactions = tempTransactions;
            this.transactions = transactions;
        }

        // GET: TransactionCheck
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var currentTransactions = this.transactions.GetAll().Where(x => x.UserId == userId);

            foreach (var transaction in currentTransactions)
            {
                var temp = this.Mapper.Map<TransactionViewModel>(transaction);
                this.tempTransactions.Add(temp);
            }

            var viewModel = this.tempTransactions;

            return this.View(viewModel);
        }
    }
}
