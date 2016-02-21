using System.ComponentModel.DataAnnotations;

namespace Lazybank.Data.Models
{
    public class Company : Customer
    {
        [Required]
        [StringLength(13)]
        [MinLength(9)]
        public string UnifiedIdentityCode { get; set; }
    }
}
