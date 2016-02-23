using Lazybank.Data.Models;
using Lazybank.Web.Infrastructure.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lazybank.Web.ViewModels
{
    public class TransferPaymentInputViewModel : IMapTo<TransferPayment>
    {
        public string OrderingAccount { get; set; }

        [Required]
        [StringLength(22)]
        [MinLength(22)]
        public string BeneficiaryAccount { get; set; }

        public string OrderingName { get; set; }

        public string OrderingBank { get; set; }

        public string BeneficiaryName { get; set; }

        public CurrencyType Currency { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(120)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Details")]
        public string PaymentDetails { get; set; }

        public int AccountId { get; set; }
    }
}