namespace Lazybank.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Company : Customer
    {
        [Required]
        [StringLength(13)]
        [MinLength(9)]
        public string UnifiedIdentityCode { get; set; }
    }
}
