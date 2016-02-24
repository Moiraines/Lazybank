using Lazybank.Data.Models;
using Lazybank.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazybank.Web.ViewModels
{
    public class OrdersViewModel : IMapFrom<ApplicationUser>
    {
        public ICollection<TransferPaymentViewModel> Orders { get; set; }
    }
}