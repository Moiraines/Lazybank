namespace Lazybank.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using Lazybank.Common;
    using Lazybank.Data;
    using Lazybank.Web.Infrastructure.Mapping;
    using System.Web.Mvc;
    public class FeedbackInputModel : IMapTo<Lazybank.Data.Models.Feedback>
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}