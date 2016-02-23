namespace Lazybank.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Lazybank.Data.Common.Models;
    using System;
    public abstract class Payment : BaseModel<int>
    {
        [Required]
        [StringLength(22)]
        [MinLength(22)]
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

        public bool IsSigned { get; set; }

        public StatusType Status { get; set; }

        [Required]
        [StringLength(120)]
        public string PaymentDetails { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int AccountId { get; set; }

        public virtual BankAccount Account { get; set; }
    }
}
