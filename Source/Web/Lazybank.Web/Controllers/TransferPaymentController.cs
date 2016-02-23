﻿using Lazybank.Data.Models;
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
            var viewModel = this.Mapper.Map<BalanceViewModel>(currentUser);

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BalanceViewModel globalModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(globalModel);
            }

            var model = globalModel.TransferPayment;

            if (model.BeneficiaryAccount == model.OrderingAccount)
            {
                this.TempData["Account Duplicate"] = "Order and Beneficary Account can not be the same!";
                return this.View(globalModel);
            }

            if (model.OrderingName == model.BeneficiaryName)
            {
                this.TempData["Customer Name Duplicate"] = "Order and Beneficary Name can not be the same!";
                return this.View(globalModel);
            }

            var newPayment = this.Mapper.Map<TransferPayment>(model);
            newPayment.CreatedOn = DateTime.Now;
            newPayment.AccountId = this.accounts.GetId(model.OrderingAccount);
            newPayment.IsSigned = true;
            newPayment.Status = StatusType.Completed;
            this.payments.Create(newPayment);

            this.TempData["Notification"] = "Payment succesfully made!";
            return this.Redirect("/MovementCheck");
        }
    }
}