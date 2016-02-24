namespace Lazybank.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Lazybank.Data.Common.Models;

    public class Feedback : BaseModel<int>
    {
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
