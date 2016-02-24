namespace Lazybank.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Lazybank.Data.Models;
    using Lazybank.Web.Infrastructure.Mapping;

    public class TransferPaymentViewModel : IMapFrom<TransferPayment>
    {
        public int Id { get; set; }

        [Display(Name = "Payer Account")]
        public string OrderingAccount { get; set; }

        [Display(Name = "Payer Name")]
        public string BeneficiaryAccount { get; set; }

        [Display(Name = "Payee Account")]
        public string OrderingName { get; set; }

        [Display(Name = "Payee Name")]
        public string BeneficiaryName { get; set; }

        public decimal Amount { get; set; }

        [UIHint("DateTime")]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        public StatusType Status { get; set; }
    }
}
