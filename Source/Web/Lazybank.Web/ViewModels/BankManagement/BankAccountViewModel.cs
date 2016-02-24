namespace Lazybank.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Lazybank.Data.Models;
    using Lazybank.Web.Infrastructure.Mapping;

    public class BankAccountViewModel : IMapFrom<BankAccount>
    {
        public int Id { get; set; }

        [Display(Name = "Account Number")]
        public string Number { get; set; }

        public CurrencyType Currency { get; set; }

        public decimal Balance { get; set; }
    }
}
