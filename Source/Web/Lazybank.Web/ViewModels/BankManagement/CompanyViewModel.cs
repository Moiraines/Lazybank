using Lazybank.Data.Models;
using Lazybank.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazybank.Web.ViewModels
{
    public class CompanyViewModel : IMapFrom<Company>
    {
        public string Name { get; set; }

        public ICollection<BankAccountViewModel> Accounts { get; set; }
    }
}