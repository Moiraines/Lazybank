using Lazybank.Data.Models;
using Lazybank.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazybank.Web.ViewModels
{
    public class UserForPaymentsViewModel : IMapFrom<ApplicationUser>
    {
        public ICollection<CompanyViewModel> Companies { get; set; }

        public ICollection<IndividualViewModel> Individuals { get; set; }
    }
}