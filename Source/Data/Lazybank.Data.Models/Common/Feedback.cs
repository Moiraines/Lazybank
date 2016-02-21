using Lazybank.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazybank.Data.Models
{
    public class Feedback : BaseModel<int>
    {
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
