namespace Lazybank.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Data.Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

       // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IDeletableEntity, IAuditInfo
    {
        private ICollection<Individual> individuals;
        private ICollection<Company> companies;
        private ICollection<RightContainer> rights;
        private ICollection<TransferPayment> payments;
        private ICollection<Transaction> transactions;

        public ApplicationUser()
        {
            this.individuals = new HashSet<Individual>();
            this.companies = new HashSet<Company>();
            this.rights = new HashSet<RightContainer>();
            this.payments = new HashSet<TransferPayment>();
            this.transactions = new HashSet<Transaction>();
            this.CreatedOn = DateTime.Now;
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Individual> Individuals
        {
            get
            {
                return this.individuals;
            }

            set
            {
                this.individuals = value;
            }
        }

        public virtual ICollection<Company> Companies
        {
            get
            {
                return this.companies;
            }

            set
            {
                this.companies = value;
            }
        }

        public virtual ICollection<RightContainer> Rights
        {
            get
            {
                return this.rights;
            }

            set
            {
                this.rights = value;
            }
        }

        public virtual ICollection<TransferPayment> Payments
        {
            get
            {
                return this.payments;
            }

            set
            {
                this.payments = value;
            }
        }

        public virtual ICollection<Transaction> Transactions
        {
            get
            {
                return this.transactions;
            }

            set
            {
                this.transactions = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
