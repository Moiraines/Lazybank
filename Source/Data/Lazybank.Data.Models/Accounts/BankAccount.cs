namespace Lazybank.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Lazybank.Data.Common.Models;

    public class BankAccount : BaseModel<int>
    {
        private ICollection<Transaction> transactions;
        private ICollection<LocalPayment> localPayments;
        private ICollection<BudgetPayment> budgetPayments;
        private ICollection<TransferPayment> transferPayments;
        private ICollection<RightContainer> rights;

        public BankAccount()
        {
            this.transactions = new HashSet<Transaction>();
            this.localPayments = new HashSet<LocalPayment>();
            this.budgetPayments = new HashSet<BudgetPayment>();
            this.transferPayments = new HashSet<TransferPayment>();
            this.rights = new HashSet<RightContainer>();
            this.CreatedOn = DateTime.Now;
        }

        [Required]
        [StringLength(22)]
        [MinLength(22)]
        public string Number { get; set; }

        [Required]
        public CurrencyType Currency { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        public decimal Balance { get; set; }

        [Required]
        public AccountType Type { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public int IndividualId { get; set; }

        public virtual Individual Individual { get; set; }

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

        public virtual ICollection<LocalPayment> LocalPayments
        {
            get
            {
                return this.localPayments;
            }

            set
            {
                this.localPayments = value;
            }
        }

        public virtual ICollection<BudgetPayment> BudgetPayments
        {
            get
            {
                return this.budgetPayments;
            }

            set
            {
                this.budgetPayments = value;
            }
        }

        public virtual ICollection<TransferPayment> TransferPayments
        {
            get
            {
                return this.transferPayments;
            }

            set
            {
                this.transferPayments = value;
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
    }
}
