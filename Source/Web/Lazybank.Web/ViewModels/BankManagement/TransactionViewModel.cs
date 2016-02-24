namespace Lazybank.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Lazybank.Data.Models;
    using Lazybank.Web.Infrastructure.Mapping;

    public class TransactionViewModel : IMapFrom<Transaction>
    {
        public int Id { get; set; }

        [Display(Name = "Account Number")]
        public string OrderingAccount { get; set; }

        public CurrencyType Currency { get; set; }

        public decimal Amount { get; set; }

        [Display(Name = "Details")]
        public string PaymentDetails { get; set; }

        [Display(Name = "Type")]
        public TransactionType TransactionType { get; set; }

        [UIHint("DateTime")]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
    }
}
