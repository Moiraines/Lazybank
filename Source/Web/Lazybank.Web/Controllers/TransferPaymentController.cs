using Lazybank.Data.Models;
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
        private ITransactionsService transactions;
        private ITransferPaymentsService payments;
        private IBankAccountsService accounts;

        public TransferPaymentController(IUsersService users, ITransactionsService transactions, ITransferPaymentsService payments, IBankAccountsService accounts)
        {
            this.users = users;
            this.transactions = transactions;
            this.payments = payments;
            this.accounts = accounts;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var userId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(userId);
            var globalmodel = new OutputPaymentModel();
            globalmodel.User = this.Mapper.Map<UserForPaymentsViewModel>(currentUser);
            return this.View(globalmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OutputPaymentModel globalModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(globalModel);
            }

            var model = globalModel.TransferPayment;

            var userId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(userId);
            var newGlobalModel = globalModel;
            if (model.BeneficiaryAccount == model.OrderingAccount)
            {
                newGlobalModel.User = this.Mapper.Map<UserForPaymentsViewModel>(currentUser);
                this.TempData["Account Duplicate"] = "Order and Beneficary Account can not be the same!";
                return this.View(newGlobalModel);
            }

            if (model.OrderingName == model.BeneficiaryName)
            {
                newGlobalModel.User = this.Mapper.Map<UserForPaymentsViewModel>(currentUser);
                this.TempData["Customer Name Duplicate"] = "Order and Beneficary Name can not be the same!";
                return this.View(newGlobalModel);
            }

            var newPayment = this.Mapper.Map<TransferPayment>(model);
            newPayment.CreatedOn = DateTime.Now;
            newPayment.AccountId = this.accounts.GetId(model.OrderingAccount);
            newPayment.IsSigned = true;
            newPayment.Status = StatusType.Completed;
            this.payments.Create(newPayment);


            // TODO: Extract Copy Transaction logic
            var transaction = new Transaction
            {
                OrderingAccount = newPayment.OrderingAccount,
                BeneficiaryAccount = newPayment.BeneficiaryAccount,
                OrderingName = newPayment.OrderingName,
                BeneficiaryName = newPayment.BeneficiaryName,
                Currency = newPayment.Currency,
                Amount = newPayment.Amount,
                PaymentDetails = newPayment.PaymentDetails,
                CreatedOn = newPayment.CreatedOn,
                AccountId = newPayment.AccountId,
                TransactionType = TransactionType.Debit
            };
            this.transactions.Create(transaction);

            var transactionRereversed = new Transaction
            {
                OrderingAccount = newPayment.OrderingAccount,
                BeneficiaryAccount = newPayment.BeneficiaryAccount,
                OrderingName = newPayment.OrderingName,
                BeneficiaryName = newPayment.BeneficiaryName,
                Currency = newPayment.Currency,
                Amount = newPayment.Amount,
                PaymentDetails = newPayment.PaymentDetails,
                CreatedOn = newPayment.CreatedOn,
                AccountId = this.accounts.GetId(model.BeneficiaryAccount),
                TransactionType = TransactionType.Credit
            };
            this.transactions.Create(transactionRereversed);

            this.TempData["Notification"] = "Payment succesfully made!";
            return this.Redirect("/MovementCheck");
        }
    }
}