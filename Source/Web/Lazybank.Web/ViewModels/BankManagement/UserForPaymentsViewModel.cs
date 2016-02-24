namespace Lazybank.Web.ViewModels
{
    using System.Collections.Generic;

    using Lazybank.Data.Models;
    using Lazybank.Web.Infrastructure.Mapping;
    
    public class UserForPaymentsViewModel : IMapFrom<ApplicationUser>
    {
        public ICollection<CompanyViewModel> Companies { get; set; }

        public ICollection<IndividualViewModel> Individuals { get; set; }
    }
}
