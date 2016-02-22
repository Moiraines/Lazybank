namespace Lazybank.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using Lazybank.Common;
    using Lazybank.Data;
    using Lazybank.Web.Infrastructure.Mapping;

    public class NewsArticleInputModel : IMapTo<NewsArticle>
    {
        [Required]
        [MinLength(GlobalConstants.ArticleTitleMinLength)]
        [MaxLength(GlobalConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(GlobalConstants.ArticleContentMinLength)]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}