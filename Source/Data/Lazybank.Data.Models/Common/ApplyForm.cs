namespace Lazybank.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Lazybank.Data.Common.Models;

    public class ApplyForm : BaseModel<int>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [MinLength(9)]
        public string IdentificationNumber { get; set; }

        public int Address { get; set; }

        public IDictionary<BankAccount, RightType> AccountsRights { get; set; }

        public IDictionary<BankAccount, CurrencyType> AccountsCurrencies { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
