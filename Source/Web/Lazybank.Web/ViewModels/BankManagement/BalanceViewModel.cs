namespace Lazybank.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Lazybank.Data.Models;
    using Lazybank.Web.Infrastructure.Mapping;

    public class BalanceViewModel : IMapFrom<ApplicationUser>
    {
        public ICollection<CompanyViewModel> Companies { get; set; }

        public ICollection<IndividualViewModel> Individuals { get; set; }

    }
}