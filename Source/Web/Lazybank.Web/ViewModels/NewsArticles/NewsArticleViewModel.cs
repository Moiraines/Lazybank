namespace Lazybank.Web.ViewModels
{
    using System;

    using Infrastructure;
    using Lazybank.Common;
    using Lazybank.Data;
    using Lazybank.Web.Infrastructure.Mapping;
    using Services.Web;

    public class NewsArticleViewModel : IMapFrom<NewsArticle>
    {
        private readonly ISanitizer sanitizer;

        public NewsArticleViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => this.sanitizer.Sanitize(this.Content);

        public string ImageUrl { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/NewsArticle/Details/{identifier.EncodeId(this.Id)}";
            }
        }

        //public string ShortContent
        //{
        //    get
        //    {
        //        int lastSpace = this.Content.LastIndexOf(' ', this.Content.Length > GlobalConstants.NewsArticleShortContentLength ? GlobalConstants.NewsArticleShortContentLength : this.Content.Length - 1);
        //        string shortContent = this.Content.Substring(0, lastSpace);
        //        return $"{shortContent} ...";
        //    }
        //}

        public DateTime CreatedOn { get; set; }
    }
}