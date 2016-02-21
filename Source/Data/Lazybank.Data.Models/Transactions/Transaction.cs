namespace Lazybank.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Lazybank.Data.Common.Models;

    public class Transaction : BaseModel<int>
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

        public string BeneficiaryName { get; set; }

        public CurrencyType Currency { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(120)]
        public string PaymentDetails { get; set; }

        public TransactionType TransactionType { get; set; }

        public int AccountId { get; set; }

        public virtual BankAccount Account { get; set; }
    }
}
