namespace Lazybank.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Lazybank.Data.Common.Models;

    public class BankAccount : BaseModel<int>
    {
        [Required]
        [StringLength(22)]
        [MinLength(22)]
        public string Number { get; set; }

        [Required]
        public CurrencyType Currency { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        public decimal Balance { get; set; }

        [Required]
        public AccountType Type { get; set; }

        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public string IndividualId { get; set; }

        public virtual Individual Individual { get; set; }
    }
}
