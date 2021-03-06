﻿namespace Lazybank.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;
    using Lazybank.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<BankAccount> Accounts { get; set; }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<Individual> Individuals { get; set; }

        public IDbSet<NewsArticle> Articles { get; set; }

        public IDbSet<ApplyForm> ApplyForms { get; set; }

        public IDbSet<Feedback> Feedbacks { get; set; }

        public IDbSet<Transaction> Transactions { get; set; }

        public IDbSet<BudgetPayment> Budgetpayments { get; set; }

        public IDbSet<LocalPayment> LocalPayments { get; set; }

        public IDbSet<TransferPayment> TransferPayments { get; set; }

        public IDbSet<RightContainer> Rights { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
