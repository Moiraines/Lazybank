using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazybank.Data.Models
{
    public class Individual : Customer
    {
        [Required]
        public string PersonalIdNumber { get; set; }
    }
}
