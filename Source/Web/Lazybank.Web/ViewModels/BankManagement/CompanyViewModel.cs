namespace Lazybank.Web.ViewModels
{
    using System.Collections.Generic;

    using Lazybank.Data.Models;
    using Lazybank.Web.Infrastructure.Mapping;

    public class CompanyViewModel : IMapFrom<Company>
    {
        public string Name { get; set; }

        public ICollection<BankAccountViewModel> Accounts { get; set; }
    }
}
