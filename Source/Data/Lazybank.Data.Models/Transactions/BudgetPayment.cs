namespace Lazybank.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BudgetPayment : Payment
    {
        public string BeneficiaryBank { get; set; }

        public string ObligatedPersonName { get; set; }

        [StringLength(13)]
        [MinLength(9)]
        public string Bulstat { get; set; }

        public string Pin { get; set; }

        public DocumentType DocumentType { get; set; }

        public string LiabilityDocumentNumber { get; set; }
    }
}
