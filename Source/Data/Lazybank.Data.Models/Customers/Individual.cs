namespace Lazybank.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Individual : Customer
    {
        [Required]
        public string PersonalIdNumber { get; set; }
    }
}
