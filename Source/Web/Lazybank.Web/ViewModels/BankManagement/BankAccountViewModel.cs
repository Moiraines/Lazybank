using Lazybank.Data.Models;
using Lazybank.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lazybank.Web.ViewModels
{
    public class BankAccountViewModel : IMapFrom<BankAccount>
    {
        public int Id { get; set; }

        [Display(Name = "Account Numer")]
        public string Number { get; set; }

        public CurrencyType Currency { get; set; }

        public decimal Balance { get; set; }
    }
}