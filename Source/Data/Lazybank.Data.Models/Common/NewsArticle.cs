using Lazybank.Data.Common.Models;
using Lazybank.Data.Models;
using Lazybank.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazybank.Data
{
    public class NewsArticle : BaseModel<int>
    {
        [Required]
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
