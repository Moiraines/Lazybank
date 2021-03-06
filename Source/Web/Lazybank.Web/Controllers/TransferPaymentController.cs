﻿namespace Lazybank.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using Lazybank.Data.Models;
    using Lazybank.Services.Data;
    using Lazybank.Web.ViewModels;
    using Microsoft.AspNet.Identity;

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
            var newGlobalModel = globalModel;
            var userId = this.User.Identity.GetUserId();
            var currentUser = this.users.GetById(userId);

            var orderingAccNumber = model.OrderingAccount;
            var orderingAccount = this.accounts.GetAccount(orderingAccNumber);

            if (orderingAccount.Balance < model.Amount)
            {
                newGlobalModel.User = this.Mapper.Map<UserForPaymentsViewModel>(currentUser);
                this.TempData["insufficient funds"] = "insufficient funds in the account";
                return this.View(newGlobalModel);
            }

            var beneficaryAccNumber = model.BeneficiaryAccount;
            var beneficaryAccount = this.accounts.GetAccount(beneficaryAccNumber);

            this.accounts.BalanceAccounts(orderingAccount, beneficaryAccount, model.Amount);

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
            newPayment.UserId = userId;
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
                UserId = newPayment.UserId,
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
                UserId = newPayment.UserId,
                TransactionType = TransactionType.Credit
            };
            this.transactions.Create(transactionRereversed);

            this.TempData["Notification"] = "Payment succesfully made!";
            return this.Redirect("/OrdersArchive");
        }
    }
}
