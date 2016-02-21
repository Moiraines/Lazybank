namespace Lazybank.Data.Models
{
    using System.Collections.Generic;

    using Lazybank.Data.Common.Models;

    public class ApplyForm : BaseModel<int>
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string IdentificationNumber { get; set; }

        public int Address { get; set; }

        public IDictionary<BankAccount, RightType> AccountsRights { get; set; }

        public IDictionary<BankAccount, CurrencyType> AccountsCurrencies { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
