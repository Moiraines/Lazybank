namespace Lazybank.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Lazybank.Data.Common.Models;

    public abstract class Customer : BaseModel<int>
    {
        private ICollection<BankAccount> accounts;
        private ICollection<ApplicationUser> users;

        public Customer()
        {
            this.accounts = new HashSet<BankAccount>();
            this.users = new HashSet<ApplicationUser>();
            this.CreatedOn = DateTime.Now;
        }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [Range(100000000, 999999999)]
        public int ClientNumber { get; set; }

        public int Address { get; set; }

        public virtual ICollection<BankAccount> Accounts
        {
            get
            {
                return this.accounts;
            }

            set
            {
                this.accounts = value;
            }
        }

        public virtual ICollection<ApplicationUser> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }
    }
}
