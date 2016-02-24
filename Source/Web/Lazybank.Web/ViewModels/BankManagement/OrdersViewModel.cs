namespace Lazybank.Web.ViewModels
{
    using System.Collections.Generic;
    using Lazybank.Data.Models;
    using Lazybank.Web.Infrastructure.Mapping;

    public class OrdersViewModel : IMapFrom<ApplicationUser>
    {
        public ICollection<TransferPaymentViewModel> Orders { get; set; }
    }
}
