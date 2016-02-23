namespace Lazybank.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using Lazybank.Common;
    using Lazybank.Data;
    using Lazybank.Web.Infrastructure.Mapping;
    using System.Web.Mvc;
    using Data.Models;

    public class FeedbackInputModel : IMapTo<Feedback>
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