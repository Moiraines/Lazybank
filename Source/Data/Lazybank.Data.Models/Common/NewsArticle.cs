namespace Lazybank.Data
{
    using System.ComponentModel.DataAnnotations;

    using Lazybank.Common;
    using Lazybank.Data.Common.Models;
    using Lazybank.Data.Models;

    public class NewsArticle : BaseModel<int>
    {
        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(GlobalConstants.ArticleContentMinLength)]
        public string Content { get; set; }

        [Required]
        [MinLength(GlobalConstants.ArticleTitleMinLength)]
        [MaxLength(GlobalConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string ImageUrl { get; set; }
    }
}
